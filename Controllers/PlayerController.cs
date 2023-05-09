using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]

public class PlayerController : ControllerBase
{
    public Context _context {get; set;}

    public PlayerController(Context x){
        _context = x;
    }

    [Route("/addplayer/{firstname}/{lastname}/{age}/{height}/{jersey}/{position}/{teamname}")]
    [HttpPost]

    public async Task<IActionResult> AddPlayer(string firstname, string lastname, int age, int height, int jersey, int position, string teamname)
    {   
        if (position < 1 || position > 5)
        {
            return BadRequest("Ta pozicija ne postoji");
        }

        var proveraDresa = await _context.Players.Where(xx => xx.Jersey == jersey && xx.Team.TeamName == teamname).FirstOrDefaultAsync();
        if( proveraDresa != null)
        {
            return BadRequest("Taj broj na dresu u tom klubu vec postoji");
        }

        

        var team =  await _context.Teams.Where(xx => xx.TeamName == teamname).FirstAsync();

        if (team == null){
            return BadRequest("Ne postoji takav tim!");
        }

       

        var ObjPlayer = new Player();
        ObjPlayer.FirstName = firstname;
        ObjPlayer.LastName = lastname;
        ObjPlayer.Age = age;
        ObjPlayer.Height = height;
        ObjPlayer.Team = team;
        ObjPlayer.Position = position;
        
        ObjPlayer.Jersey = jersey;
        ObjPlayer.PlayForTeam = team.TeamName;



        await _context.Players.AddAsync(ObjPlayer);
        await _context.SaveChangesAsync();
        return Ok ("Igrac je dodat " + firstname + " " + lastname);
    }


    
    [Route("/deletepalyer/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeletePlayer(int id){

        var player = await _context.Players.FindAsync(id);
        if(player == null)
        {
            return BadRequest("Takav igrac ne postoji!"); 
        };

        var statesplayer = await _context.States.Where(xx => xx.Player == player).ToListAsync();
        statesplayer.ForEach(xx =>{
            _context.States.Remove(xx);            
        });
        
        _context.Players.Remove(player);

        await _context.SaveChangesAsync();
        return Ok("Uspesno obrinsano");
    }


    [Route("/listplayersperteam/{teamname}")]
    [HttpGet]
    public async Task<List<Player>> ListPlayerperTeam(string teamname){

        var listplayersperteam = await _context.Players.Where(xx => xx.Team.TeamName == teamname).ToListAsync();
        return listplayersperteam;
    }


    [Route("/memberofteams/{teamname}")]
    [HttpGet]
    public async Task<List<Player>> MemberOfTeams(string teamname){
        return _context.Players.Where(xx => xx.Team.TeamName == teamname ).GroupBy(e => e.Team)
                    .Select(x => new Player()
                    {
                        Team = x.Key,
                        Counter = x.Count(),
                    }).ToList();
    }

    [Route("/listallplayers")]
    [HttpGet]
    public async Task<List<Player>> ListPlayers(){
        return await _context.Players.ToListAsync();     
    }


} 
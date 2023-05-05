using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
   public Context _context {get; set;}
   public TeamController(Context x){
    _context = x;
    }

    [Route("/addteam/{teamname}/{owner}/{numberofwins}/{street}/{buildingnumber}")]
    [HttpPost]
    public async Task<IActionResult> AddTeam(string teamname, string owner, int numberofwins, string street, string buildingnumber){
        


        var proveraimenatima = await _context.Teams.Where(xx => xx.TeamName == teamname).FirstOrDefaultAsync();

        if(proveraimenatima != null)
        {
            return BadRequest("Tim sa tim imenom vec postoji");
        }

        
       
        var city = new City();

        var brojtimova = await _context.Teams.ToListAsync(); 
        brojtimova.Count();


        if( brojtimova.Count() % 2 == 0)
        {

            var grad = await _context.Cities.Where(xx => xx.NameCity == "Nis").FirstAsync();
            
            var proveralokacije = await _context.Teams.Where(xx => xx.Street == street && xx.BuildingNumber == buildingnumber && xx.City == grad).FirstOrDefaultAsync();
            if(proveralokacije != null)
            {
                return BadRequest("Tim je vec registrovan na toj adresi");
            }

            city = grad;
           

        }else{
            var grad = await _context.Cities.Where(xx => xx.NameCity == "Beograd").FirstAsync();
            
            var proveralokacije = await _context.Teams.Where(xx => xx.Street == street && xx.BuildingNumber == buildingnumber && xx.City == grad).FirstOrDefaultAsync();
            if(proveralokacije != null)
            {
                return BadRequest("Tim je vec registrovan na toj adresi");
            }

            city = grad;
           
        } 
        var ObjTeam = new Team();
        ObjTeam.City = city;
        
        ObjTeam.TeamName = teamname;
        ObjTeam.Owner = owner;
        ObjTeam.NumberOfWins = numberofwins;
        ObjTeam.Street = street;
        ObjTeam.BuildingNumber = buildingnumber;
        ObjTeam.NameCities = city.NameCity;

        await _context.Teams.AddAsync(ObjTeam);
        await _context.SaveChangesAsync();
        return Ok("Uspesno upisano");     

    }

    [Route("/listteam")]
    [HttpGet]
    public async Task<List<Team>> ListTeam(){

        return await _context.Teams.ToListAsync();     

    }

    [Route("/delteteam/{id}")]
    [HttpDelete]

    public async Task<IActionResult> DeleteTeam(int id){
        
        var team = await _context.Teams.FindAsync(id);
        if(team == null){
            return BadRequest("Tim sa tim ID ne postoji");
        }

        var playersInTeam = await _context.Players.Where(xx => xx.Team == team).ToListAsync();
        playersInTeam.ForEach(async xx=>{
            
                var stateofplayer = await _context.States.Where(bb => bb.Player == xx).ToListAsync();
                stateofplayer.ForEach(async cc => {
                    _context.States.Remove(cc);
                });

            _context.Players.Remove(xx);
        });

        _context.Teams.Remove(team);

        await _context.SaveChangesAsync();
        return Ok("uspesno izbrisan tim");
    }

    [Route("/editteam/{id}/{teamname}/{owner}/{numberofwins}/{street}/{buildingnumber}")]
    [HttpPut]
    public async Task<IActionResult> UpdateTeam(int id, string teamname, string owner, int numberofwins, string street, string buildingnumber){

        var team = await _context.Teams.FindAsync(id);
        if(team == null){
            return BadRequest("Tim sa tim ID ne postoji");
        }

        var ObjTeam = await _context.Teams.FindAsync(id);

        ObjTeam.TeamName = teamname;
        ObjTeam.Owner = owner;
        ObjTeam.NumberOfWins = numberofwins;
        ObjTeam.Street = street;
        ObjTeam.BuildingNumber = buildingnumber;

        _context.Teams.Update(ObjTeam);

        await _context.SaveChangesAsync();
        return Ok("Uspesno prepravljen");
    }


    

}

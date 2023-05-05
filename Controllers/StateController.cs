using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]

public class StateController : ControllerBase
{
    public Context _context {get; set;}

    public StateController(Context x){
        _context = x;
    }

    [Route("/addstate/{score}/{shoot}/{assistance}/{match}/{idplayer}")]
    [HttpPost]
    public async Task<IActionResult> AddState(int score, int shoot, int assistance, string match, int idplayer)
    {
        
        
        var ObjPlayer = await _context.Players.FindAsync(idplayer);
        if(ObjPlayer == null){
            return BadRequest("Ne postoji igrac sa tim id");
        }
          
        
        var ObjState = new State();
        
        ObjState.Score = score;
        ObjState.Shoot = shoot;
        ObjState.Asissitance = assistance;
        ObjState.Match = match;
        ObjState.Player = ObjPlayer;
 
        await _context.States.AddAsync(ObjState);
        await _context.SaveChangesAsync();
        return Ok ("Statistika je dodata");
    }

    [Route("/liststateplayer/{idplayer}")] //prikaz statistike igraca po utakmici
    [HttpGet]
    public async Task<List<State>> ListStatePlayer(int idplayer){
        var liststateplayer = await _context.States.Where(xx => xx.Player.Id == idplayer).ToListAsync();
        return liststateplayer; 
    }


    [Route("/topfiveperscore")]
    [HttpGet]
    public async Task<List<State>> TopFivePerPlayer(){
        
        return _context.States.GroupBy(e => e.Player)
                    .Select(x => new State()
                    {
                        Player = x.Key,
                        Score = x.Sum(xx => xx.Score),
                    }).OrderByDescending(s => s.Score).Take(5).ToList();
    }

    [Route("/worstfiveperassist")]
    [HttpGet]
    public async Task<List<State>> WorstFivePerAssist(){
        
        return _context.States.GroupBy(e => e.Player)
                    .Select(x => new State()
                    {
                        Player = x.Key,
                        Asissitance = x.Sum(xx => xx.Asissitance),
                    }).OrderBy(s => s.Asissitance).Take(5).ToList();
    }



}
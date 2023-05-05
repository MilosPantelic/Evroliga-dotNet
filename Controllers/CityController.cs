using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace test.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
   public Context _context {get; set;}
   public CityController(Context x){
    _context = x;
    }

    [Route("/addcity/{namecity}")]
    [HttpPost]
    public async Task<IActionResult> AddCity(string namecity){

        var ObjCity = new City();

        ObjCity.NameCity = namecity;

        await _context.Cities.AddAsync(ObjCity);
        await _context.SaveChangesAsync();
        return Ok("Uspesno upisan grad");     

    }

    [Route("/listcity")]
    [HttpGet]
    public async Task<List<City>> ListCity(){

        return await _context.Cities.ToListAsync();     

    }

}

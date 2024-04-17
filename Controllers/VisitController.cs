using Microsoft.AspNetCore.Mvc;

namespace APBD4.Controllers;



[Route("api/visits/")]
[ApiController]
public class VisitController : ControllerBase
{
    private List<List<Visit>> _visits = new()
    {
        new List<Visit>{new (){VisitTime = DateTime.Today, Animal = new(){ Id = 2, Name = "Mickey", Category = "Mouse", Mass = 0.8, CoatColor = "Black"}, Description = "Spoko", Price = 1000}}
    };
        
    [HttpGet("{id:int}")]
    public IActionResult getAnimalVisitLists(int id)
    {

        var list = _visits.FirstOrDefault(a => a.Any(e => e.Animal.Id == id));
        if (list == null)
        {
            return NotFound($"A visit with animal id: {id} was not found" );
        }
        return Ok(list);
    }
    
    [HttpPost("{id:int}")]
    public IActionResult addAnimalVisit(Visit visit, int id) // nie dziala
    {
        var list = _visits.FirstOrDefault(a => a.Any(e => e.Animal.Id == id));
        ref List<Visit> refe = ref list; 
        if (refe == null)
        {
            return NotFound($"A visit with animal id: {id} was not found" );
        }
        refe.Add(visit); 
        return Ok(visit);
    }
}
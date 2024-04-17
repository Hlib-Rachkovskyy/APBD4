using Microsoft.AspNetCore.Mvc;

namespace APBD4.Controllers;



[Route("api/visits/")]
[ApiController]
public class VisitsController : ControllerBase
{
    private static List<List<Visit>> _visits = new()
    {
        new List<Visit>{new (){VisitTime = DateTime.Today, Animal = new(){ Id = 2, Name = "Mickey", Category = "Mouse", Mass = 0.8, CoatColor = "Black"}, Description = "Spoko", Price = 1000}, new (){VisitTime = DateTime.Today, Animal = new(){ Id = 2, Name = "Mickey", Category = "Mouse", Mass = 0.8, CoatColor = "Black"}, Description = "Spoko", Price = 1000}},
        new List<Visit>{new (){VisitTime = DateTime.Today, Animal = new(){ Id = 3, Name = "SomeAnimal", Category = "Mouse", Mass = 0.8, CoatColor = "Black"}, Description = "Spoko", Price = 1000}, new (){VisitTime = DateTime.Today, Animal = new(){ Id = 3, Name = "SomeAnimal", Category = "Mouse", Mass = 0.8, CoatColor = "Black"}, Description = "Spoko", Price = 1000}}
    };
        
    [HttpGet("{id:int}")]
    public IActionResult GetAnimalVisitLists(int id)
    {

        var list = _visits.FirstOrDefault(a => a.Any(e => e.Animal.Id == id));
        if (list == null)
        {
            return NotFound($"A visit with animal id: {id} was not found" );
        }
        return Ok(list);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult AddAnimalVisit(Visit visit, int id)
    {
        var visitsForAnimal = _visits.FirstOrDefault(a => a.Any(e => e.Animal.Id == id));

        if (visitsForAnimal == null)
        {
            return NotFound($"No visits found for animal with id: {id}");
        }

        visitsForAnimal.Add(visit);

        return NoContent();
    }
}
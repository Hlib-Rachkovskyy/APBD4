using Microsoft.AspNetCore.Mvc;

namespace APBD4.Controllers;


[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{

    private static readonly List<Animal> _animals = new()
    {
        new Animal() { Id = 1, Name = "John", Category = "Pies", Mass = 3.5, CoatColor = "Purple"}, 
        new Animal() { Id = 2, Name = "Mickey", Category = "Mouse", Mass = 0.8, CoatColor = "Black"},
        new Animal() { Id = 3, Name = "Daniel", Category = "Monkey", Mass = 5, CoatColor = "Brown"}

    };
        
        
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("id:int")]
    public IActionResult getAnimals(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);

        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(animal);
    }
    
}
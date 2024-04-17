using Microsoft.AspNetCore.Mvc;

namespace APBD4.Controllers;


[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{

    private static readonly List<Animal> Animals = new()
    {
        new Animal() { Id = 1, Name = "John", Category = "Pies", Mass = 3.5, CoatColor = "Purple"}, 
        new Animal() { Id = 2, Name = "Mickey", Category = "Mouse", Mass = 0.8, CoatColor = "Black"},
        new Animal() { Id = 3, Name = "Daniel", Category = "Monkey", Mass = 5, CoatColor = "Brown"}

    };
        
        
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);

        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult PostAnimal(Animal animal)
    {
        Animals.Add(animal);
        return Created("", animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult PutAnimal(int id, Animal animal)
    {
        var animalToSwap = Animals.FirstOrDefault(a => a.Id == id);
        animal.Id = id;
        if ( animalToSwap == null)
        {
            return NotFound($"Animal with id: {id} not found");
        }

        Animals.Remove(animalToSwap);
        Animals.Add(animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = Animals.FirstOrDefault(a => a.Id == id);
        if ( animalToDelete == null)
        {
            return NotFound($"Animal with id: {id} was not found");
        }

        Animals.Remove(animalToDelete);
        
        return NoContent();
    }

    
}
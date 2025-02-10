using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/flowers")]
public class FlowerController : ControllerBase
{
    private static List<Flower> flowers = new List<Flower>
    {
        new Flower { Id = 1, Name = "Rose", Color = "Red", Price = 5.99 },
        new Flower { Id = 2, Name = "Tulip", Color = "Yellow", Price = 3.49 }
    };

    [HttpGet]
    public IActionResult GetFlowers()
    {
        return Ok(flowers);
    }

    [HttpPost]
    public IActionResult AddFlower(Flower flower)
    {
        flower.Id = flowers.Count + 1;
        flowers.Add(flower);
        return CreatedAtAction(nameof(GetFlowers), new { id = flower.Id }, flower);
    }
}

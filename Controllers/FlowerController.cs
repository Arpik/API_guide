using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/flowers")]
public class FlowerController : ControllerBase
{
    private readonly FlowerService _flowerService;

    public FlowerController(FlowerService flowerService)
    {
        _flowerService = flowerService;
    }

    [HttpGet]
    public IActionResult GetFlowers()
    {
        return Ok(_flowerService.GetAllFlowers());
    }

    [HttpPost]
    public IActionResult AddFlower([FromBody] Flower flower)
    {
        if (string.IsNullOrWhiteSpace(flower.Name) || string.IsNullOrWhiteSpace(flower.Color))
        {
            return BadRequest("Flower name and color are required.");
        }

        var addedFlower = _flowerService.AddFlower(flower);
        return CreatedAtAction(nameof(GetFlowers), new { id = addedFlower.Id }, addedFlower);
    }
}

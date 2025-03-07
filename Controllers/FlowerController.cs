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
    public async Task<IActionResult> AddFlower([FromBody] Flower flower)
    {
        if (string.IsNullOrWhiteSpace(flower.Name) || string.IsNullOrWhiteSpace(flower.Color))
        {
            return BadRequest("Flower name and color are required.");
        }

        var addedFlower = await _flowerService.AddFlowerAsync(flower);
        return CreatedAtAction(nameof(GetFlowers), new { id = addedFlower.Id }, addedFlower);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFlower(int id, [FromBody] Flower flower)
    {
        if (id != flower.Id)
        {
            return BadRequest("Flower ID mismatch.");
        }

        var updatedFlower = _flowerService.UpdateFlower(flower);

        if (updatedFlower == null)
        {
            return NotFound($"Flower with ID {id} not found.");
        }

        return NoContent(); // 204 No Content (successful update)
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFlower(int id)
    {
        var isDeleted = _flowerService.DeleteFlower(id);

        if (!isDeleted)
        {
            return NotFound($"Flower with ID {id} not found.");
        }

        return NoContent(); // 204 No Content (successful deletion)
    }
}

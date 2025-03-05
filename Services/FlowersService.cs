public class FlowerService
{
    private readonly ApplicationDbContext _context;

    public async Task<Flower> AddFlowerAsync(Flower flower)
    {
        _context.Flowers.Add(flower);
        await _context.SaveChangesAsync();
        return flower;
    }

    public FlowerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Flower> GetAllFlowers()
    {
        return _context.Flowers.ToList();
    }

    public Flower? UpdateFlower(Flower updatedFlower)
    {
        var existingFlower = _context.Flowers.FirstOrDefault(f => f.Id == updatedFlower.Id);
        
        if (existingFlower == null)
        {
            return null; // Not found
        }

        existingFlower.Name = updatedFlower.Name;
        existingFlower.Color = updatedFlower.Color;
        existingFlower.Price = updatedFlower.Price;

        _context.SaveChanges(); // Save changes to the database

        return existingFlower;
    }
}

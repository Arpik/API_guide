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
}

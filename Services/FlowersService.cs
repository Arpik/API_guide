public class FlowerService
{
    private readonly ApplicationDbContext _context;

    public FlowerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Flower> GetAllFlowers()
    {
        return _context.Flowers.ToList();
    }

    public Flower AddFlower(Flower flower)
    {
        _context.Flowers.Add(flower);
        _context.SaveChanges();
        return flower;
    }
}

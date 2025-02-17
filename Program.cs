using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register SQLite database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=flowers.db"));

// Register FlowerService
builder.Services.AddScoped<FlowerService>();

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
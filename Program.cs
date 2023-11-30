using Microsoft.EntityFrameworkCore;
using Store.ItemManager.Database;
using Store.ItemManager.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=WIN-HIL9DGD410O\\MSSQLSERVER01;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ItemService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

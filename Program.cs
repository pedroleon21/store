using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Store.Data;
using Store.Handlers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICreateUserHandler, CreateUserHandler>();
builder.Services.AddTransient<IGetUserHandler, GetUserHandler>();
builder.Services.AddTransient<ICreateLojaHandler, CreateLojaHandler>();
builder.Services.AddTransient<IGetLojaHandler, GetLojaHandler>();
builder.Services.AddTransient<ICreateProdutoHandler, CreateProdutoHandler>();
builder.Services.AddTransient<IGetProdutoHandler, GetProdutoHandler>();
builder.Services.AddTransient<IDeleteProdutoHandler, DeleteProdutoHandler>();
builder.Services.AddTransient<IListProdutosHandler, ListProdutosHandler>();
builder.Services.AddTransient<IAuthHandler, AuthHandler>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IListLojaHandler, ListLojaHandler>();
builder.Services.AddTransient<IDeleteLojaHandler, DeleteLojaHandler>();
builder.Services.AddTransient<ICatalogEventHandler, CatalogEventHandler>();
builder.Services.AddTransient<IUpdateProdutoHandler, UpdateProdutoHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.MapGet("/", async (DataContext dbContext) =>
{
    var status = "OK";
    try
    {
        await dbContext.Database.CanConnectAsync();
    }
    catch
    {
        status = "Database Connection Failed";
    }
    var currentTime = DateTime.Now;

    var healthCheckResponse = new
    {
        currentTime,
        status

    };

    return Results.Ok(healthCheckResponse);
});
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
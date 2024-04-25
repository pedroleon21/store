using Microsoft.EntityFrameworkCore;
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

builder.Services.AddTransient<ICreateUserHandler, CreateUserHandler>();
builder.Services.AddTransient<IGetUserHandler, GetUserHandler>();
builder.Services.AddTransient<ICreateLojaHandler, CreateLojaHandler>();
builder.Services.AddTransient<IGetLojaHandler, GetLojaHandler>();
builder.Services.AddTransient<ICreateProdutoHandler, CreateProdutoHandler>();
builder.Services.AddTransient<IGetProdutoHandler, GetProdutoHandler>();
builder.Services.AddTransient<IDeleteProdutoHandler, DeleteProdutoHandler>();
builder.Services.AddTransient<IListProdutosHandler, ListProdutosHandler>();
builder.Services.AddTransient<IAuthHancler, AuthHancler>();
builder.Services.AddTransient<IEmailSender, EmailSender>();

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
app.MapGet("/", () =>
{
    var currentTime = DateTime.Now;

    var healthCheckResponse = new
    {
        currentTime,
        status = "OK"
    };

    return Results.Ok(healthCheckResponse);
});

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
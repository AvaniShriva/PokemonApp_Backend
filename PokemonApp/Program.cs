using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Repository.Interface;
using PokemonApp.Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationdbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));
builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();
builder.Services.AddTransient<ITypetable, TypeTabledata>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

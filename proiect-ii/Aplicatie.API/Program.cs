using Microsoft.EntityFrameworkCore;
using ReteteInternationale.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
  options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AplicatieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReteteConnectionString")));



//  Adaugă CORS
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularApp", policy =>
  {
    policy.WithOrigins("http://localhost:4200") // portul implicit pentru Angular
          .AllowAnyHeader()
          .AllowAnyMethod();
  });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//  Activează CORS aici
app.UseCors("AllowAngularApp");


app.UseAuthorization();

app.MapControllers();

app.Run();

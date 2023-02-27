using Microsoft.EntityFrameworkCore;
using fmsapi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ACE42023Context>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
JsonConvert.SerializeObject(System.Xml.Formatting.Indented,
new JsonSerializerSettings
{
    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
});

   
builder.Services.AddApiVersioning(x =>  
    {  
       // x.DefaultApiVersion = new ApiVersion(1.0, 0);  
        x.AssumeDefaultVersionWhenUnspecified = true;  
        x.ReportApiVersions = true;  
    });  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(options=>options.WithOrigins("http://localhost:7286/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();

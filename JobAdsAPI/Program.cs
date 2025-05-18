/* relationships to add:
 
 * One-to-One => A JobAd has one detailed JobDescription
 * One-to-Many =>  A JobAd can have many Tags (if in add is mentioned keywords)
 * Many-to-Many => A JobAd can have many Locations 
 
 */


using JobAdsAPI.Data;
using JobAdsAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<JobAdDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // after adding Scalar.AspNetCore
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();

/* relationships to add:
 

 * Many-to-Many => A JobAd can have many Locations 
 
 * To check/fix:
 * JobType or something like this still exists in the database
 * Update all CRUD methods to include the new relationships
 * options for seeding data at the same time?
 
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

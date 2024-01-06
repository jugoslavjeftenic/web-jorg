

using Jorg.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// lokalni SQL server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("LocalJorgDBServer"));
});

// Add services to the container.
builder.Services.AddControllers();

// Azure SQL server
//var sqlConnection = builder.Configuration["ConnectionStrings:Jorg:SqlDb"];
//builder.Services.AddSqlServer<JorgDbContext>(sqlConnection, options => options.EnableRetryOnFailure());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

// Azure SQL server
//app.CreateDbIfNotExists();

app.Run();

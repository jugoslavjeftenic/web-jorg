

using Jorg.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//	options.UseSqlServer(builder.Configuration.GetConnectionString("JorgDB"));
//});

// Add services to the container.
builder.Services.AddControllers();

var sqlConnection = builder.Configuration["ConnectionStrings:Jorg:SqlDb"];
builder.Services.AddSqlServer<JorgDbContext>(sqlConnection, options => options.EnableRetryOnFailure());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();

using Jorg.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("JorgApi", client =>
{
	client.BaseAddress = new Uri("https://app-jorg-api-westeu-dev-001.azurewebsites.net/api/v1/");
	//client.BaseAddress = new Uri("https://localhost:7040/api/v1/");
	client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IWebApiExecutor, WebApiExecutor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default routing
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Countries}/{action=Index}/{id?}");

app.Run();

namespace Jorg.Api.Data
{
	public static class Extensions
	{
		public static void CreateDbIfNotExists(this IHost host)
		{
			using var scope = host.Services.CreateScope();

			var services = scope.ServiceProvider;
			var jorgContext = services.GetRequiredService<JorgDbContext>();

			jorgContext.Database.EnsureCreated();

			DBInitializer.InitializeDatabase(jorgContext);
		}
	}
}

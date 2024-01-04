namespace Jorg.Web.Data
{
	public class WebApiExecutor(IHttpClientFactory httpClientFactory) : IWebApiExecutor
	{
		private const string apiName = "JorgApi";
		private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

		public async Task<T?> InvokeGet<T>(string relativeUrl)
		{
			var httpClient = _httpClientFactory.CreateClient(apiName);
			return await httpClient.GetFromJsonAsync<T>(relativeUrl);
		}
	}
}

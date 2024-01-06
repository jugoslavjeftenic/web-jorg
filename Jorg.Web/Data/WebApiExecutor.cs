using Jorg.Web.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Jorg.Web.Data
{
	public class WebApiExecutor(IHttpClientFactory httpClientFactory) : IWebApiExecutor
	{
		private const string _apiName = "JorgApi";
		private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

		public async Task<T?> InvokeGet<T>(string relativeUrl)
		{
			var httpClient = _httpClientFactory.CreateClient(_apiName);
			return await httpClient.GetFromJsonAsync<T>(relativeUrl);
		}

		public async Task<T?> InvokePost<T>(string relativeUrl, T obj)
		{
			var httpClient = _httpClientFactory.CreateClient(_apiName);
			// Konvertuj ContinentEnum u indeks pre slanja na API
			if (obj is CountryModel countryModel)
			{
				countryModel.Continent = countryModel.Continent.Value;
				Console.WriteLine(countryModel.Continent.ToString());
			}

			//var response = await httpClient.PostAsJsonAsync(relativeUrl, obj);
			var response = await httpClient.PostAsJsonAsync(relativeUrl, obj);
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadFromJsonAsync<T>();
		}
	}
}

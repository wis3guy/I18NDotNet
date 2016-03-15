using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I18N
{
	public abstract class GoogleI18NService : IDisposable
	{
		private const string BaseUri = "http://i18napis.appspot.com";

		private HttpClient _httpClient;

		protected GoogleI18NService()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri(BaseUri)
			};
		}

		protected async Task<T> GetTypedResponse<T>(string path)
		{
			var response = await _httpClient.GetAsync(path);

			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			var typed = JsonConvert.DeserializeObject<T>(json);
			return typed;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
				return;

			if (_httpClient == null)
				return;

			_httpClient.Dispose();
			_httpClient = null;
		}
	}
}
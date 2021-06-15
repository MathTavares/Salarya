using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;

namespace Salarya.Services
{
	public class RestService : IDisposable
	{
		HttpClient _client;

		public RestService()
		{
			_client = new HttpClient();
		}

		public async Task<List<BustaMensile>> GetRepositoriesAsync(string uri)
		{
			List<BustaMensile> repositories = null;
			try
			{
				HttpResponseMessage response = await _client.GetAsync(uri);
				response.Dispose();
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					repositories = JsonConvert.DeserializeObject<List<BustaMensile>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("\tERROR {0}", ex.Message);
			}

			return repositories;
		}

		public void Dispose()
		{
			_client?.Dispose();
		}
	}
}

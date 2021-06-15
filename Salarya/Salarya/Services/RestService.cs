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
			List<BustaMensile> repositories = new List<BustaMensile>();
			try
			{
				if (!uri.Equals("2021"))
				{
					HttpResponseMessage response = await _client.GetAsync(uri);
					response.Dispose();
					if (response.IsSuccessStatusCode)
					{
						string content = await response.Content.ReadAsStringAsync();
						repositories = JsonConvert.DeserializeObject<List<BustaMensile>>(content);
					}
				}
				else
				{
					repositories.Add(new BustaMensile()
					{
						Nome = "Math",
						Mese = "Aprile",
						Netto = 1555.54,
						Lordo = 1810.34,
						FerieDovute = 12,
						FerieGodute = 2,
						OreMaturate = 88,
						OreGodute = 6
					});

					repositories.Add(new BustaMensile()
					{
						Nome = "Math",
						Mese = "Marzo",
						Netto = 1666.54,
						Lordo = 1910.34,
						FerieDovute = 16,
						FerieGodute = 2,
						OreMaturate = 35,
						OreGodute = 5
					});

					repositories.Add(new BustaMensile()
					{
						Nome = "Math",
						Mese = "Febbraio",
						Netto = 1999.54,
						Lordo = 1980.34,
						FerieDovute = 55,
						FerieGodute = 2,
						OreMaturate = 35,
						OreGodute = 2
					});
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

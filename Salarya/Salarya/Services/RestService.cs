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

					//var questionsList = JsonConvert.DeserializeObject<BustaMensile>(JsonFile);

					repositories.Add(new BustaMensile()
					{
						Year = 2021,
						FirstName = "Math",
						Month = "Febbraio",
						NetSalary = (decimal)1999.54,
						GrossSalary = (decimal)1980.34,
						HolidayDue = 11,
						HolidayEnjoyed = 2,
						PermitsDue = 35,
						PermitsEnjoyed = 2
					});

					repositories.Add(new BustaMensile()
					{
						Year = 2021,
						FirstName = "Math",
						Month = "Marzo",
						NetSalary = (decimal)1666.54,
						GrossSalary = (decimal)1980.34,
						HolidayDue = 22,
						HolidayEnjoyed = 2,
						PermitsDue = 35,
						PermitsEnjoyed = 2
					});

					repositories.Add(new BustaMensile()
					{
						Year = 2021,
						FirstName = "Math",
						Month = "Aprile",
						NetSalary = (decimal)1777.54,
						GrossSalary = (decimal)1980.34,
						HolidayDue = 33,
						HolidayEnjoyed = 2,
						PermitsDue = 35,
						PermitsEnjoyed = 2
					});

				
					
				}
				
			}
			catch (Exception ex)
			{
				Debug.WriteLine("\tERROR {0}", ex.Message);
			}

		

			return repositories;
		}


		public string JsonFile = "";

		public void Dispose()
		{
			_client?.Dispose();
		}
	}
}

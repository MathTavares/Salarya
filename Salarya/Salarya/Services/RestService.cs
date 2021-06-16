using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;
using Android.Content.Res;
using Android;
using System.IO;
using System.Linq;

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
				if (string.IsNullOrEmpty(uri))
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


					#region LOAD DATA

					repositories.Add(new BustaMensile()
					{
						IdPDFSalary = 0,
						 Year = 2021,
						 Month = "GIUGNO",
						 FirstName = "MARIO",
						 LastName = "VERDI",
						 Qualification = "IMPIEGATO",
						 CodTax = "VRDMRO25E04G444T",
						 HolidayDue = (decimal)5.76,
						 HolidayEnjoyed = (decimal)3.00,
						 HolidayResidual = (decimal)2.76,
						 PermitsDue = (decimal)27.00,
						 PermitsEnjoyed = (decimal)0.00,
						 PermitsResidual = (decimal)27.00,
						 NetSalary = (decimal)1472.53,
						 GrossSalary = (decimal)2069.77
					});

					repositories.Add(new BustaMensile()
					{
						IdPDFSalary = 0,
						Year = 2021,
						Month = "LUGLIO",
						FirstName = "MARIO",
						LastName = "VERDI",
						Qualification = "IMPIEGATO",
						CodTax = "VRDMRO25E04G444T",
						HolidayDue = (decimal)5,
						HolidayEnjoyed = (decimal)3.00,
						HolidayResidual = (decimal)2,
						PermitsDue = (decimal)27.00,
						PermitsEnjoyed = (decimal)4.00,
						PermitsResidual = (decimal)27.00,
						NetSalary = (decimal)1572.53,
						GrossSalary = (decimal)2169.77
					});

					repositories.Add(new BustaMensile()
					{
						 IdPDFSalary = 0,
							 Year = 2021,
							 Month = "GIUGNO",
							 FirstName = "GIANNA",
							 LastName = "GIONNO",
							 Qualification = "IMPIEGATO",
							 CodTax = "GNNGNN15F04G454S",
							 HolidayDue = (decimal)5,
							 HolidayEnjoyed = (decimal)2.00,
							 HolidayResidual = (decimal)3,
							 PermitsDue = (decimal)27.00,
							 PermitsEnjoyed = (decimal)3.00,
							 PermitsResidual = (decimal)24.00,
							 NetSalary = (decimal)1491.12,
							 GrossSalary = (decimal)2198.14
					});

					//repositories.Add(new BustaMensile()
					//{
					//	Year = 2021,
					//	FirstName = "Math",
					//	Month = "Aprile",
					//	NetSalary = (decimal)1777.54,
					//	GrossSalary = (decimal)1980.34,
					//	HolidayDue = 33,
					//	HolidayEnjoyed = 2,
					//	PermitsDue = 35,
					//	PermitsEnjoyed = 2
					//});
					#endregion



				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine("\tERROR {0}", ex.Message);
			}



			return repositories.Where(x => string.Equals(x.CodTax, uri)).ToList();
			//return repositories;
		}


		public string JsonFile = "";

		public void Dispose()
		{
			_client?.Dispose();
		}
	}
}

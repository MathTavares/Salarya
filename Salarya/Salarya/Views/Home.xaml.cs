using Salarya.Models;
using Salarya.ViewModels;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;

namespace Salarya.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	//[QueryProperty(nameof(CodiceFiscale), "CodiceFiscale")]
	public partial class Home : ContentPage
	{
		private readonly List<Microcharts.ChartEntry> _entries = new List<Microcharts.ChartEntry>()
		{
			new Microcharts.ChartEntry(200)
			{
				Label = "jan",
				ValueLabel = "200",
				Color = SKColor.Parse("#FF0033")
			}
		};

		private DonutChart _chart;
		public DonutChart chart
		{
			get => _chart;
			set
			{
				if (_chart != value)
				{
					_chart = value;
					OnPropertyChanged(nameof(chart));
				}
			}
		}

		public Home()
		{
			InitializeComponent();
			//((HomeViewModel)this.BindingContext).CodiceFiscale = CodiceFiscale;
			//Carosel.CurrentItemChanged += Carosel_CurrentItemChanged;

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var entries = new[]
			{
				 new ChartEntry(212)
				 {
					Label = "UWP",
					ValueLabel = "212",
					Color = SKColor.Parse("#2c3e50")
				 },
				 new ChartEntry(248)
				 {
					Label = "Android",
					ValueLabel = "248",
					Color = SKColor.Parse("#77d065")
				 },
				 new ChartEntry(128)
				 {
					Label = "iOS",
					ValueLabel = "128",
					Color = SKColor.Parse("#b455b6")
				 },
				 new ChartEntry(514)
				 {
					Label = "Shared",
					ValueLabel = "514",
					Color = SKColor.Parse("#3498db")
				}
			};

			chart = new DonutChart() { Entries = entries };
		}

		private void Carosel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
		{

			if (sender is CarouselView carouselView)
			{
			}
		}

		private ObservableCollection<ChartDataModel> _ferieSeriesDataTest;

		public ObservableCollection<ChartDataModel> FerieSeriesDataTest
		{
			get => _ferieSeriesDataTest;
			set
			{
				if (_ferieSeriesDataTest != value)
				{
					_ferieSeriesDataTest = value;
					OnPropertyChanged(nameof(FerieSeriesDataTest));
				}

			}
		}

	}
}
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

namespace Salarya.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	//[QueryProperty(nameof(CodiceFiscale), "CodiceFiscale")]
	public partial class Home : ContentPage
	{

		//public string CodiceFiscale { get; set; }
		public Home()
		{
			InitializeComponent();
			//((HomeViewModel)this.BindingContext).CodiceFiscale = CodiceFiscale;
			//Carosel.CurrentItemChanged += Carosel_CurrentItemChanged;

		}

		//public string CodiceFiscale
		//{
		//	set
		//	{

		//	};
		//	get;
		//}

		private void Carosel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
		{
		
			if(sender is CarouselView carouselView)
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
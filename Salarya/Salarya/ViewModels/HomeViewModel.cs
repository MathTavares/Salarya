using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Salarya.Models;

namespace Salarya.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }

		public HomeViewModel()
		{
			StipendioVM = new PermessiOreViewModel(new ObservableCollection<ChartDataModel>
				{
					 new ChartDataModel("Importo netto", 1650.42),
					 new ChartDataModel("Addizionali", 200),
					 new ChartDataModel("Trattenute", 150.42),
			  });
			PermessiVM = new PermessiOreViewModel(new ObservableCollection<ChartDataModel>
				{
					 new ChartDataModel("ore maturate", 180),
					 new ChartDataModel("ore godute", 15),
			  });
			FerieVM = new PermessiOreViewModel(new ObservableCollection<ChartDataModel>
				{
					 new ChartDataModel("gg maturati", 45),
					 new ChartDataModel("gg goduti", 3),
			  });

			MeseCorrente = "Aprile 2021";
			StipendioNetto = "1658.69 €";
			BuoniPasto = 22;
		}

		private PermessiOreViewModel _permessiVM;
		private PermessiOreViewModel _ferieVM;
		private PermessiOreViewModel _stipendioVM;
		private string _meseCorrente;
		private string _stipendioNetto;
		private int _buoniPasto;

		public PermessiOreViewModel PermessiVM
		{
			get => _permessiVM;
			set
			{
				_permessiVM = value;
				OnPropertyChanged(nameof(PermessiVM));
			}
		}
		public PermessiOreViewModel FerieVM
		{
			get => _ferieVM;
			set
			{
				_ferieVM = value;
				OnPropertyChanged(nameof(FerieVM));
			}
		}
		public PermessiOreViewModel StipendioVM
		{
			get => _stipendioVM;
			set
			{
				_stipendioVM = value;
				OnPropertyChanged(nameof(StipendioVM));
			}
		}

		public string MeseCorrente
		{
			get => _meseCorrente;
			set
			{
				_meseCorrente = value;
				OnPropertyChanged(nameof(MeseCorrente));
			}
		}
		public string StipendioNetto
		{
			get => _stipendioNetto;
			set
			{
				_stipendioNetto = value;
				OnPropertyChanged(nameof(StipendioNetto));
			}
		}
		public int BuoniPasto
		{
			get => _buoniPasto;
			set
			{
				_buoniPasto = value;
				OnPropertyChanged(nameof(StipendioNetto));
			}
		}

	}
}


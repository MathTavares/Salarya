using Salarya.Models;
using Salarya.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Salarya.ViewModels
{
	public class MensilitaViewModel : BaseViewModel, INotifyPropertyChanged
	{
		
		public MensilitaViewModel(BustaMensile busta)
		{
			StipendioVM = new PermessiOreViewModel(new ObservableCollection<ChartDataModel>
				{
					 new ChartDataModel("Net Amount", busta.NetSalary),
					 new ChartDataModel("Deductions", busta.GrossSalary - busta.NetSalary),
			  });
			PermessiVM = new PermessiOreViewModel(new ObservableCollection<ChartDataModel>
				{
					 new ChartDataModel("accrued hours", busta.PermitsDue),
					 new ChartDataModel("used hours", busta.PermitsEnjoyed),
			  });
			FerieVM = new PermessiOreViewModel(new ObservableCollection<ChartDataModel>
				{
					 new ChartDataModel("accrued days", busta.HolidayDue),
					 new ChartDataModel("used days", busta.HolidayEnjoyed),
			  });

			MeseCorrente = $"{busta.Month} {busta.Year}";
			StipendioNetto = $"{busta.NetSalary} €";
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

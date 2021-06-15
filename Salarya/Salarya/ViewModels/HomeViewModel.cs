using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Salarya.Models;
using Salarya.Services;
using System.Threading.Tasks;

namespace Salarya.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		public HomeViewModel()
		{
			Task.Run(async () => await GetYear("2021"));
		}

		public async Task GetYear(string url)
		{
			using (var restService = new RestService())
			{
				_listOfYear = await restService.GetRepositoriesAsync(url);
				MensilitaViewModels = new ObservableCollection<MensilitaViewModel>();
				foreach (var mese in _listOfYear)
				{
					MensilitaViewModels.Add(new MensilitaViewModel(mese));
				}

				CurrentItem = MensilitaViewModels?.FirstOrDefault();
				OnPropertyChanged("CurrentItem");
			}

		}


		private string _meseCorrente;
		private List<BustaMensile> _listOfYear;
		private ObservableCollection<MensilitaViewModel> _mensilitaViewModels;
		private MensilitaViewModel _currentItem;

		public string MeseCorrente
		{
			get => _meseCorrente;
			set
			{
				_meseCorrente = value;
				OnPropertyChanged(nameof(MeseCorrente));
			}
		}
		public ObservableCollection<MensilitaViewModel> MensilitaViewModels
		{
			get => _mensilitaViewModels;
			set
			{
				_mensilitaViewModels = value;
				OnPropertyChanged(nameof(MensilitaViewModels));
			}
		}

		public MensilitaViewModel CurrentItem
		{
			get => _currentItem;
			set
			{
				_currentItem = value;
				OnPropertyChanged(nameof(CurrentItem));
			}
		}

	}
}


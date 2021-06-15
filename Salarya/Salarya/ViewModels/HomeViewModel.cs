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

		private void UpdateCurrentData()
		{
			FerieSeriesData = CurrentItem.FerieVM.DoughnutSeriesData;
		}


		private string _meseCorrente;
		private List<BustaMensile> _listOfYear;
		private ObservableCollection<MensilitaViewModel> _mensilitaViewModels;
		private MensilitaViewModel _currentItem;
		private ObservableCollection<ChartDataModel> _ferieSeriesData;

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
				if(_mensilitaViewModels != null)
				{
					_mensilitaViewModels.CollectionChanged -= _mensilitaViewModels_CollectionChanged;
				}
				_mensilitaViewModels = value;
				if (_mensilitaViewModels != null)
				{
					_mensilitaViewModels.CollectionChanged += _mensilitaViewModels_CollectionChanged;
				}
				OnPropertyChanged(nameof(MensilitaViewModels));
			}
		}

		private void _mensilitaViewModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnCollectionChanged(() => MensilitaViewModels);
		}

		public MensilitaViewModel CurrentItem
		{
			get => _currentItem;
			set
			{
				_currentItem = value;
				UpdateCurrentData();
				OnPropertyChanged(nameof(CurrentItem));
			}
		}

		public ObservableCollection<ChartDataModel> FerieSeriesData
		{
			get => _ferieSeriesData;
			set
			{
				_ferieSeriesData = value;
				OnPropertyChanged(nameof(CurrentItem));
			}
		}

	}
}


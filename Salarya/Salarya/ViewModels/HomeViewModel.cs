using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Salarya.Models;
using Salarya.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Salarya.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		public HomeViewModel()
		{
			Task.Run(async () => await GetYear());

			RefreshCommand = new Command(async () => await GetYear());
		}

		public async Task GetYear()
		{
			using (var restService = new RestService())
			{
				IsRefreshing = true;
				_listOfYear = await restService.GetRepositoriesAsync("2021");

				var tempMensilitaViewModels = new ObservableCollection<MensilitaViewModel>();
				foreach (var mese in _listOfYear)
				{
					tempMensilitaViewModels.Add(new MensilitaViewModel(mese));
				}

				
				try
				{
					
					MensilitaViewModels = tempMensilitaViewModels;
					IsRefreshing = false;
				}
				catch (Exception ex)
				{
					System.Console.WriteLine(ex);
				}
				
				
				CurrentItem = MensilitaViewModels?.LastOrDefault();
				OnPropertyChanged("CurrentItem");
				
			}
		}

		private void UpdateCurrentData()
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				FerieSeriesData?.Clear();
				FerieSeriesData = CurrentItem?.FerieVM?.DoughnutSeriesData;
			});
		
		}


		private string _meseCorrente;
		private List<BustaMensile> _listOfYear;
		private ObservableCollection<MensilitaViewModel> _mensilitaViewModels;
		private MensilitaViewModel _currentItem;
		private ObservableCollection<ChartDataModel> _ferieSeriesData;
		private bool _isRefreshing;

		public ICommand RefreshCommand { protected set; get; }

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
				if(_mensilitaViewModels != value)
				{
					_mensilitaViewModels = value;
					if (_mensilitaViewModels != null)
					{
						_mensilitaViewModels.CollectionChanged += _mensilitaViewModels_CollectionChanged;
					}
					OnPropertyChanged(nameof(MensilitaViewModels));
				}
			}
		}

		private void _mensilitaViewModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnCollectionChanged(() => MensilitaViewModels);
		}

		private void _ferie_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnCollectionChanged(() => FerieSeriesData);
		}

		public MensilitaViewModel CurrentItem
		{
			get => _currentItem;
			set
			{
				if(_currentItem != value)
				{
					_currentItem = value;
					UpdateCurrentData();
					OnPropertyChanged(nameof(CurrentItem));
				}
			}
		}

		public ObservableCollection<ChartDataModel> FerieSeriesData
		{
			get => _ferieSeriesData;
			set
			{
				if (_ferieSeriesData != null)
				{
					_ferieSeriesData.CollectionChanged -= _ferie_CollectionChanged;
				}
				if (_ferieSeriesData != value)
				{
					_ferieSeriesData = value;
					if (_ferieSeriesData != null)
					{
						_ferieSeriesData.CollectionChanged += _ferie_CollectionChanged;
					}
					OnPropertyChanged(nameof(FerieSeriesData));
				}

			}
		}

		public bool IsRefreshing
		{
			get => _isRefreshing;
			set
			{
				_isRefreshing = value;
				OnPropertyChanged(nameof(IsRefreshing));
			}
		}

		public string CodiceFiscale { get; set; }

	}
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Salarya.Models;

namespace Salarya.ViewModels
{
	public class PermessiOreViewModel : BaseViewModel, INotifyPropertyChanged
	{
		

		public PermessiOreViewModel(ObservableCollection<ChartDataModel> data)
		{
			DoughnutSeriesData = data;
	
		}
		private int selectedIndex;
		private string _selectedItemName;
		private decimal _selectedItemsPercentage;
		private decimal _sum;
		private string _stringSum;
		private ObservableCollection<ChartDataModel> _doughnutSeriesData;

		public string SelectedItemName
		{
			get => _selectedItemName;
			set
			{
				_selectedItemName = value;
				OnPropertyChanged(nameof(SelectedItemName));
			}
		}


		public decimal SelectedItemsPercentage
		{
			get => _selectedItemsPercentage;
			set
			{
				_selectedItemsPercentage = value;
				OnPropertyChanged(nameof(SelectedItemsPercentage));
			}
		}

		public decimal Sum
		{
			get => _sum;
			set
			{
				_sum = value;
				OnPropertyChanged(nameof(Sum));
			}
		}

		public string StringSum
		{
			get => _stringSum;
			set
			{
				_stringSum = value;
				OnPropertyChanged(nameof(StringSum));
			}
		}

		public int SelectedIndex
		{
			get { return selectedIndex; }
			set
			{
				selectedIndex = value;
				if (selectedIndex == -1) return;

				SelectedItemName = DoughnutSeriesData[selectedIndex].Name;

				Sum = DoughnutSeriesData.Sum(item => item.Value);
				StringSum = $"{Sum} €";
				var selectedValue = DoughnutSeriesData[selectedIndex].Value;

				SelectedItemsPercentage = selectedValue / Sum * 100;
				SelectedItemsPercentage = Math.Floor(SelectedItemsPercentage * 100) / 100;
			}
		}

		public ObservableCollection<ChartDataModel> DoughnutSeriesData
		{
			get => _doughnutSeriesData;
			set
			{
				if (_doughnutSeriesData != null)
				{
					_doughnutSeriesData.CollectionChanged -= _doughnutSeriesDataViewModels_CollectionChanged;
				}
				_doughnutSeriesData = value;
				if (_doughnutSeriesData != null)
				{
					_doughnutSeriesData.CollectionChanged += _doughnutSeriesDataViewModels_CollectionChanged;
				}
				OnPropertyChanged(nameof(DoughnutSeriesData));
			}
		}

		private void _doughnutSeriesDataViewModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnCollectionChanged(() => DoughnutSeriesData);
		}

	}
}

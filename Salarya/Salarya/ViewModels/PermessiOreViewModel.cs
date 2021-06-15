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
		public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }

		public PermessiOreViewModel(ObservableCollection<ChartDataModel> data)
		{
			DoughnutSeriesData = data;
	
		}
		private int selectedIndex;
		private string _selectedItemName;
		private double _selectedItemsPercentage;
		private double _sum;

		public string SelectedItemName
		{
			get { return _selectedItemName; }
			set
			{
				_selectedItemName = value;
				OnPropertyChanged(nameof(SelectedItemName));
			}
		}


		public double SelectedItemsPercentage
		{
			get { return _selectedItemsPercentage; }
			set
			{
				_selectedItemsPercentage = value;
				OnPropertyChanged(nameof(SelectedItemsPercentage));
			}
		}

		public double Sum
		{
			get { return _sum; }
			set
			{
				_sum = value;
				OnPropertyChanged(nameof(Sum));
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
				var selectedValue = DoughnutSeriesData[selectedIndex].Value;

				SelectedItemsPercentage = (selectedValue / Sum) * 100;
				SelectedItemsPercentage = Math.Floor(SelectedItemsPercentage * 100) / 100;
			}
		}
	}
}

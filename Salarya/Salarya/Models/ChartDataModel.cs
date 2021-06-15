using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Salarya.Models
{
	public class ChartDataModel : INotifyPropertyChanged
	{
		private string _name;
		private double _value;
		public string Name 
		{
			get => _name;
			set
			{
				_name = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
			}
		}

		public double Value
		{
			get => _value;
			set
			{
				_value = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
			}
		}


		public ChartDataModel(string name, double value)
		{
			Name = name;
			Value = value;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}

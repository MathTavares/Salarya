using Salarya.Models;
using Salarya.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Salarya.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged, INotifyCollectionChanged
	{
		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		string title = string.Empty;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		protected bool SetProperty<T>(ref T backingStore, T value,
			 [CallerMemberName] string propertyName = "",
			 Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;
		protected virtual void OnCollectionChanged<T>(Expression<Func<T>> e)
      {
            var handler = CollectionChanged;

            handler?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
      }
		#endregion
	}
}

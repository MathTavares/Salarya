using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Salarya.Views;

namespace Salarya.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			SubmitCommand = new Command(PushHomePage);
		}

		private async void PushHomePage()
		{
			if(!string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(CodiceFiscale))
			{
				await Shell.Current.GoToAsync($"//{nameof(Home)}");
			}
		}

		public ICommand SubmitCommand { protected set; get; }

		private string _nome;
		public string Nome
		{
			get => _nome;
			set
			{
				_nome = value;
				OnPropertyChanged(nameof(Nome));
			}
		}

		private string _codiceFiscale;
		public string CodiceFiscale
		{
			get => _codiceFiscale;
			set
			{
				_codiceFiscale = value;
				OnPropertyChanged(nameof(CodiceFiscale));
			}
		}

	}
}
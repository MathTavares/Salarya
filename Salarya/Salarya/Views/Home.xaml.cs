using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Salarya.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home()
		{
			InitializeComponent();
		}

		//protected override void OnSizeAllocated(double width, double height)
		//{
		//	base.OnSizeAllocated(width, height);
		//	if ((Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS))
		//	{
		//		if (height > 0 && width > 0)
		//		{
		//			if (height > width)
		//			{
		//				doughnutSeriesStipendio.CenterView = stackStipendio;
		//				ChartStipendio.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
		//				ChartStipendio.Legend.DockPosition = LegendPlacement.Bottom;
		//			}
		//			else
		//			{
		//				doughnutSeriesStipendio.CenterView = stackStipendio;
		//				ChartStipendio.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
		//				ChartStipendio.Legend.DockPosition = LegendPlacement.Bottom;
		//			}
		//		}
		//	}
		//}
	}
}
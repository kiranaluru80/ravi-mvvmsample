using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ReadDataFromJson
{
	public partial class ReadDataFromJsonPage : ContentPage
	{
		public ReadDataFromJsonPage()
		{
			InitializeComponent();

			this.BindingContext = new ReadDataViewModel();


		}
	}
}

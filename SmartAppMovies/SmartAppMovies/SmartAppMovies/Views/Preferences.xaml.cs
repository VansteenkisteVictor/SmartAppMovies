using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartAppMovies.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Preferences : ContentPage
	{
		public Preferences ()
		{
			InitializeComponent ();
            BindingContext = App.ViewModelLocator.PreferencesViewModel;
            Title = "Preferences";
        }
	}
}
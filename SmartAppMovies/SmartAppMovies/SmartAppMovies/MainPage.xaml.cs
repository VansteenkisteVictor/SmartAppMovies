using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartAppMovies
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.ViewModelLocator.MainPageViewModel;
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}

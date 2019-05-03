using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAppMovies.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartAppMovies.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllReviews : ContentPage
	{
		public AllReviews (List<Models.Review> reviews)
		{
			InitializeComponent ();
            BindingContext = App.ViewModelLocator.AllReviewsPageViewModel;
            App.ViewModelLocator.AllReviewsPageViewModel.Reviews = reviews;
            Title = "All Reviews";
        }
	}
}
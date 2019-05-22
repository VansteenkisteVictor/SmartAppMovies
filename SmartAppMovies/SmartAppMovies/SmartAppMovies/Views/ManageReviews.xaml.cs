using SmartAppMovies.Models;
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
	public partial class ManageReviews : ContentPage
	{
		public ManageReviews(List<Review> reviews)
		{
			InitializeComponent ();
            BindingContext = App.ViewModelLocator.ManageReviewsViewModel;
            App.ViewModelLocator.ManageReviewsViewModel.UserReviews = reviews;
            Title = "Manage Reviews";
        }
	}
}
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
	public partial class UpdateReview : ContentPage
	{
		public UpdateReview (Review review)
		{
			InitializeComponent();
            BindingContext = App.ViewModelLocator.UpdateReviewPageViewModel;
            App.ViewModelLocator.UpdateReviewPageViewModel.ReviewUpdate = review;
            Title = "Update Review";
        }
	}
}
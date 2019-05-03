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
    public partial class Review : ContentPage
    {
        public Review(MovieDetail detailMovie)
        {
            InitializeComponent();
            BindingContext = App.ViewModelLocator.ReviewPageViewModel;
            App.ViewModelLocator.ReviewPageViewModel.SelectedMovie = detailMovie;
            Title = "Review: " +  detailMovie.Title;
        }
    }
}
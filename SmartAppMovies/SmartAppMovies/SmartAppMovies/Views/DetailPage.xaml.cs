﻿using SmartAppMovies.Models;
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
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Search movieSearch)
        {
            InitializeComponent();
            BindingContext = App.ViewModelLocator.DetailPageViewModel;
            App.ViewModelLocator.DetailPageViewModel.SelectedMovie = movieSearch;
            Title = movieSearch.Title;
        }
    }
}
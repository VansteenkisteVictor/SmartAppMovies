using GalaSoft.MvvmLight.Ioc;
using SmartAppMovies.Services;
using SmartAppMovies.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartAppMovies
{
    public partial class App : Application
    {
        private static ViewModelLocator viewModelLocator;
        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                if (viewModelLocator == null)
                    viewModelLocator = new ViewModelLocator();
                return viewModelLocator;
            }
        }
        public App()
        {
            InitializeComponent();
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.MainPage, typeof(MainPage));

            SimpleIoc.Default.Register<ICustomNavigation>(() => nav);

            var mainPage = new NavigationPage(new MainPage());
            nav.Initialize(mainPage);
            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartAppMovies.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public LoginViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;

        }
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        if(Email == null || Password == null || Email == "" || Password == "")
                        {
                            Error = "One or more fields not filled in";
                        }
                        else
                        {
                            if (await LogUserIn())
                            {
                                Application.Current.Properties["UserName"] = Email;
                                _navigationService.NavigateTo(ViewModelLocator.MainPage);
                            }
                            else
                            {
                                Error = "Incorrect username or password";
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public RelayCommand navRegister
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.Register);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private string _error;
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                RaisePropertyChanged(() => Error);
            }
        }

        public async Task<bool> LogUserIn()
        {
            Login login = await _movieService.GetLogin(Email);
            byte[] inputpassword = GenerateSaltedHash(Password, login.Salt);
            if(Encoding.ASCII.GetString(inputpassword) == login.Password)
            {
                Application.Current.Properties["ID"] = login.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] GenerateSaltedHash(string password,byte[] salt)
        {
            byte[] plainText = Encoding.ASCII.GetBytes(password);
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }
            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }

    
}

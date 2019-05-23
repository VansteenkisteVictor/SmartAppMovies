using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SmartAppMovies.Models;
using SmartAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartAppMovies.ViewModels
{
    public class RegisterViewModel:ViewModelBase
    {
        private readonly IMovieService _movieService;
        private ICustomNavigation _navigationService;
        public RegisterViewModel(IMovieService movieService, ICustomNavigation navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;

        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        if(Email != null && Password != null && Password2 != null)
                        {
                            try
                            {
                                var addr = new System.Net.Mail.MailAddress(Email);
                                RegisterUser(Email, Password, Password2);
                            }
                            catch
                            {
                                Error = "Not a valid email";
                            }
                            
                        }
                        else
                        {
                            Error = "One the input fields is not filled in";
                        }
                        
                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
            }
        }

        public RelayCommand navLogin
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _navigationService.NavigateTo(ViewModelLocator.Login);
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

        private string _password2;
        public string Password2
        {
            get
            {
                return _password2;
            }
            set
            {
                _password2 = value;
                RaisePropertyChanged(() => Password2);
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

        private byte[] _salt;
        public byte[] Salt
        {
            get
            {
                return _salt;
            }
            set
            {
                _salt = value;
                RaisePropertyChanged(() => Salt);
            }
        }

        public void RegisterUser(string email, string password, string password2)
        {
            if(password == password2)
            {
                Login user = new Login();
                user.Id = new Guid();
                user.Username = email;
                user.Password = Encoding.ASCII.GetString(GenerateSaltedHash(password));
                user.Salt = Salt;
                user.Admin = "False";
                _movieService.AddLogin(user);
                Preferences.Set("UserName", user.Username);
                _navigationService.NavigateTo(ViewModelLocator.MainPage);
            }
            else
            {
                Error = "Password is not confirmed correctly";
            }
        } 

        public byte[] GenerateSaltedHash(string password)
        {
            byte[] plainText = Encoding.ASCII.GetBytes(password);
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Salt = salt;
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

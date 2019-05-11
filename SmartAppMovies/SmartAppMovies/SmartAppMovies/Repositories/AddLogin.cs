using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class AddLogin : IAddLogin
    {
        public async Task AddLoginAsync(Login login)
        {
            try
            {
                var getResponse = await "https://192.168.1.15:45457/api/login".PostJsonAsync(login);

            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

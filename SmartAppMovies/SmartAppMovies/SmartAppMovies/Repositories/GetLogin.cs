using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class GetLogin : IGetLogin
    {
        public async Task<Login> GetLoginAsync(string q)
        {
            try
            {
                var getResponse = await $"https://192.168.233.98:45456/api/login/{q}".GetJsonAsync<Login>();
                Console.WriteLine(getResponse);
                return getResponse;
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

using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class DetailRepo : IDetailRepo
    {
        public async Task<MovieDetail> GetMovieDetail(string q)
        {
            try
            {
                var getResponse = await $"http://www.omdbapi.com/?t={q}&apikey=9db84c18".GetJsonAsync<MovieDetail>();
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

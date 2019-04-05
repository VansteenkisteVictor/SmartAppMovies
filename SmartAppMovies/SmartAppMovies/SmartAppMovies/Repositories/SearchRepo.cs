using Flurl.Http;
using SmartAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppMovies.Repositories
{
    public class SearchRepo : ISearchRepo
    {
        public async Task<MovieSearch> GetMovieSearch(string q)
        {
            try
            {
                var getResponse = await $"http://www.omdbapi.com/?s={q}&apikey=9db84c18".GetJsonAsync<MovieSearch>();
                Console.WriteLine(getResponse);
                return getResponse;

            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw new Exception("Movie Not Found");
            }
        }

    }
}

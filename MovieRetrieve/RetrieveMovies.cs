using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieRetrieve
{
    class RetrieveMovies
    {
        public static async Task<IEnumerable<Movie>> GetAllMovies(string find)
        {
            var listOfMovies = new List<Movie>();
            var url = "http://jsonmock.hackerrank.com/api/movies/search/?Title=" + find;
            int page = 1;
            int allPages = 0;
            var nextUrl = $"{url}&page={page}";

            using (var httpClient = new HttpClient())
            {
                do
                {
                    HttpResponseMessage response = await httpClient.GetAsync(nextUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var pageResponse = JsonConvert.DeserializeObject<PageResponse>(json);

                        if (pageResponse != null && pageResponse.Data.Any())
                        {
                            listOfMovies.AddRange(pageResponse.Data);
                            allPages = pageResponse.TotalPages;

                            page++;
                            nextUrl = $"{url}&page={page}";
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (page == allPages);
            }

            return listOfMovies;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter movie title: ");
            string find = Console.ReadLine();
            IEnumerable<Movie> movies = GetAllMovies(find).GetAwaiter().GetResult();
            foreach(Movie mv in movies)
            {
                Console.WriteLine(mv.Title);
            }
            
            Console.Read();
        }
    }
}

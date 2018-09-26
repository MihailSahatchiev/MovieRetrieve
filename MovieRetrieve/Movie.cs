using Newtonsoft.Json;

namespace MovieRetrieve
{
    public class Movie
    {
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
    }
}
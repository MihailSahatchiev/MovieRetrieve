using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieRetrieve
{
    public class PageResponse
    {
        public string Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public IEnumerable<Movie> Data { get; set; }
    }
}


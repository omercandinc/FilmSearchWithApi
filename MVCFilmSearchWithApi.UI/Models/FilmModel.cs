using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFilmSearchWithApi.UI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class FilmModel
    {
        public string Title { get; set; } = null;
        public string Year { get; set; } = null;
        public string imdbID { get; set; } = null;
        public string Type { get; set; } = null;
        public string Poster { get; set; } = null;
    }

    public class Root
    {
        public List<FilmModel> Search { get; set; }
        public string totalResults { get; set; }
        public bool Response { get; set; }
        public string Error { get; set; }
    }
}
using MVCFilmSearchWithApi.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVCFilmSearchWithApi.UI.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(List<FilmModel> filmModel)
        {
            return View(filmModel);
        }
        [HttpPost]
        public JsonResult GetMovieByName(string Title)
        {
            var result = GetReleases("http://www.omdbapi.com/?apikey=f5011fd8&s=" + Title );
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
            
            if(myDeserializedClass.Response)
            {
                List<FilmModel> filmModel = myDeserializedClass.Search;
                return Json(new { IsSuccess = true, Model=filmModel }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { IsSuccess = false, Message = myDeserializedClass.Error });
            }
           
        }

        public static string GetReleases(string url)
        {
            var client = new WebClient();
            var response = client.DownloadString(url);
            return response;
        }
    }
}
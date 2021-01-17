using MVCFilmSearchWithApi.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVCFilmSearchWithApi.UI.Controllers
{
    public class LoginController : Controller
    {
        private static readonly Regex regex = new Regex(@"^\d+$");
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult LoginControl(string username, string password)
        {
            bool mailResult = IsValidMail(username);
            if(!mailResult)
            {
                return Json(new { IsSuccess = false, Message = "Kullanıcı adı Mail formatında olmalıdır..!" });
            }
            if (!regex.IsMatch(password))
            {
                return Json(new { IsSuccess = false, Message = "Şifre sayılardan oluşmalıdır..!" });
            }
            var result = GetApi("https://localhost:44375/api/Login/?username="+username+"&password=" + password);
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            bool loginResult = JsonConvert.DeserializeObject<bool>(result);
            if (loginResult)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Json(new { IsSuccess = true, Message = "Giriş Başarılı" });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Giriş Başarısız" });
            }
           
        }

        public bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GetApi(string url)
        {
            var client = new WebClient();
            var response = client.DownloadString(url);
            return response;
        }
    }
}
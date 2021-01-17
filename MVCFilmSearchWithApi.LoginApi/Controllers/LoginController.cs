using MVCFilmSearchWithApi.LoginApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVCFilmSearchWithApi.LoginApi.Controllers
{
    public class LoginController:ApiController
    {
        private static readonly string _username = "omercan74@gmail.com";
        private static readonly string _password = "1907";
        public bool Get(string username, string password)
        {
            if (username == _username && password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
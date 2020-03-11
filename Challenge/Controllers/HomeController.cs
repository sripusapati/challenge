using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Challenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Login")]
        public JObject loginService([FromBody] JObject loginJson)
        {
            JObject retJson = new JObject();
            string username = loginJson["username"].ToString();
            string password = loginJson["password"].ToString();
            if (username == "admin" && password == "admin")
            {
                retJson.Add(new JProperty("authentication ", "successful"));
            }
            else
            {
                retJson.Add(new JProperty("authentication ", "unsuccessful"));
            }
            return retJson;
        }
    }
}

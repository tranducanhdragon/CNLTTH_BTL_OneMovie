using Newtonsoft.Json;
using OneMovie.Client.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneMovie.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client =new RestClient("https://localhost:44305/api/");
            var request = new RestRequest("Muavips");
            var response = client.Execute(request);
            List<MuaVip> result = new List<MuaVip>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                String rawResponse = response.Content;
                result = JsonConvert.DeserializeObject<List<MuaVip>>(rawResponse);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
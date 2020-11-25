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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult index(string Username,string Password)
        {
            var client = new RestClient("https://localhost:44305/api/");
            var request = new RestRequest("Taikhoans/"+Username+"/"+Password);
            var response = client.Execute(request);
            Taikhoan resultacc = null;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultacc = new Taikhoan();
                String rawResponse = response.Content;
                resultacc = JsonConvert.DeserializeObject<Taikhoan>(rawResponse);
            }
            if(resultacc != null)
            {
                Session["username"] = resultacc.TaiKhoan1;
                string result = "true";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string result = "false";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult viewlogin()
        {
            return PartialView("_ViewPartiallogin");
        }
        public ActionResult viewregister()
        {
            return PartialView("_ViewPartialRegister");
        }
    }
}
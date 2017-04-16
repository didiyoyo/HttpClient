using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HttpClientServer.Controllers
{
    public class HttpClientController : Controller
    {
        // GET: HttpClient
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult TestGet(string name)
        {
            return Json(new { Name = name, Age = 9, Class = "大一" ,HttpMode="Get"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TestPost(string name)
        {
            return Json(new { Name = name, Age = 9, Class = "大一", HttpMode = "Post" });
        }
    }
}
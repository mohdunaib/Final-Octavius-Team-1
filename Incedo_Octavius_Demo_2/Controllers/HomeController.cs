using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incedo_Octavius_Demo_2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string uname,string password)
        {
            if (uname.ToLower() == "john")
            {
                if (password == "Yash")
                {

                 return RedirectToAction("Index", "Oncology");
                }
                else
                {
                    return Content("Wrong User Name or Password!");
                }
            }
            else if(uname.ToLower()=="jack")
            {
                if (password == "Yash")
                {


                    return RedirectToAction("Index", "Hematology");
                }
                else
                {
                    return Content("Wrong User Name or Password!");
                }
            }
            else if (uname.ToLower() == "mark")
            {
                if (password == "Yash")
                {


                    return RedirectToAction("Index", "BusinessUserHome");
                }
                else
                {
                    return Content("Wrong User Name or Password!");
                }
            }

            return Content("User Not Authorized");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Message = "Your Privacy page.";

            return View();
        }

        public ActionResult Team()
        {
            ViewBag.Message = "Our Team";
            return View();
        }
        public ActionResult SetLoginId(string uname, string password)
        {
            return Content(uname);
        }
    }
}
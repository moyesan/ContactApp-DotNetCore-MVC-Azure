using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contact_app_mvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public string Index() 
        //{
        //    return "this is contact index";
        //}

        public string Details() 
        {
            return "this is contact details";
        }
    }
}

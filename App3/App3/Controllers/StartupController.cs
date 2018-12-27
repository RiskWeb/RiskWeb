using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using App3.Models;

namespace App3.Controllers
{
    public class StartupController : Controller
    {        
        public ActionResult Login()
        {
            return View();
        }        
    }
}
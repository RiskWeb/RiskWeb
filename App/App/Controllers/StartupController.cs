using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers
{
    public class StartupController : Controller
    {        
        public ActionResult Login()
        {
            return View();
        }        
    }
}
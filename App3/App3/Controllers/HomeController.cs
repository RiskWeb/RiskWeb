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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult Run()
        {
            string runFile = "C:\\developer\\git\\Engine\\Examples\\Example_1\\run.py";

            ProcessStartInfo start = new ProcessStartInfo();
            start.WorkingDirectory = "C:\\developer\\git\\Engine\\Examples\\Example_1\\";
            start.FileName = "C:\\Users\\Admin\\AppData\\Local\\Programs\\Python\\Python37\\python.exe";
            start.Arguments = string.Format("{0} {1}", runFile, "");
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            // Console output
            AppConsole console = new AppConsole();
            StringBuilder sb = new StringBuilder();
            string str = "";

            using (Process process = Process.Start(start))
            {
                string line;
                while ((line = process.StandardOutput.ReadLine()) != null)
                {
                    sb.AppendFormat(line, Environment.NewLine);
                    str += line + Environment.NewLine;
                }

                //using (StreamReader reader = process.StandardOutput)
                //{

                //    string line;
                //    while ((line = reader.ReadLine()) != null)
                //    {
                //        //sb.AppendLine(line);
                //        sb.AppendFormat(line, Environment.NewLine);
                //    }

                //    //string result = ReadToEnd();
                //    //console.Text = result;
                //}
            }

            console.Text = str; // sb.ToString();

            return View(console);
        }       
    }
}
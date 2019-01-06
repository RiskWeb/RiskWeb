﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using App.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace App.Controllers
{
    public class RunController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IOptions<Config> _config;        

        public RunController(IHostingEnvironment env, IOptions<Config> config)
        {
            _env = env;
            _config = config;
        }

        public ActionResult Engine()
        {
            return View();
        }

        public ActionResult Console()
        {
            // TODO: Unable to read from launchSettings.json file when Docker is included.
            // With Docker enabled hosting environment path defaults to C:\ and environment to "Development"

            //string root = _config.Value.OrePath;
            string root = "C:\\developer\\git\\Engine";
            //string root = _env.ContentRootPath.ToString();

            string runFile = string.Format("{0}\\{1}", root, "Examples\\Example_1\\run.py");

            ProcessStartInfo start = new ProcessStartInfo();
            start.WorkingDirectory = string.Format("{0}\\{1}", root, "Examples\\Example_1");
            start.FileName = "python.exe"; // Assumes path to python.exe in PATH-variable
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
            }

            console.Text = str; 

            return View(console);
        }        
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Data;
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
            string root = "C:\\Development\\GitShare\\ore";
            //string root = _env.ContentRootPath.ToString();

            string runFile = string.Format("{0}\\{1}", root, "Examples\\Example_1\\run.py");
            //string runFile = string.Format("{0}\\{1}", root, "~/developer/git/ore/Engine/Examples/Example_1/run.py");

            ProcessStartInfo start = new ProcessStartInfo();
            start.WorkingDirectory = string.Format("{0}\\{1}", root, "Examples\\Example_1");
            //start.WorkingDirectory = string.Format("{0}\\{1}", root, "~/developer/git/ore/Engine/Examples/Example_1");

            start.FileName = "python"; // Assumes path to python.exe in PATH-variable
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

        public ActionResult LoadExposure()
        {            
            //string root = _config.Value.OrePath;
            string root = "C:\\Development\\GitShare\\ore";
            //string root = _env.ContentRootPath.ToString();            

            string csv_name1 = string.Format("{0}\\{1}", root, "Examples\\Example_1\\Output\\exposure_trade_Swap_20y.csv");
            string csv_name2 = string.Format("{0}\\{1}", root, "Examples\\Example_1\\Output\\swaption_npv.csv");       
            

            List<double> time = GetData(csv_name1, 2).Select(t => Math.Round(t, 1)).ToList();
            List<double> values1 = GetData(csv_name1, 3);
            List<double> values2 = GetData(csv_name1, 4);
            //List<double> values3 = GetData(csv_name1, val_colidx_1);

            Exposure model = new Exposure()
            {
                DisplayName = "Swaption",
                Time = time,
                Values1 = values1,
                Values2 = values2
            };

            return View(model);
        }

        private List<double> GetData(string fileName, int colidx, int offset = 1)
        {
            List<double> data = new List<double>();
            List<object> temp = new List<object>();

            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (colidx < line.Split(',').Length) temp.Add(line.Split(',')[colidx]);
                }
            }

            data = temp.Skip(offset).Select(d => Convert.ToDouble(d)).ToList();
           
            return data;
        }
    }
}
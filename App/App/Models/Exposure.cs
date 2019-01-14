using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class Exposure
    {
        public string DisplayName { get; set; }
        public List<double> Time { get; set; }
        public List<double> Values1 { get; set; }
        public List<double> Values2 { get; set; }
        public List<double> Values3 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class PortfolioUpload
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TradeCount { get; set; }

        public string Agreements { get; set; }

        [Display(Name = "Uploaded")]
        [DataType(DataType.DateTime)]
        public DateTime UploadTime { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "Last Run")]
        [DataType(DataType.DateTime)]
        public DateTime LastRunTime { get; set; }

    }
}

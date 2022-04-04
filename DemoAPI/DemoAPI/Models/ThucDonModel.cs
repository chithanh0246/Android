using Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class ThucDonModel
    {
        
        public int IdTD { get; set; }
        public int IdLoai { get; set; }
        public string TenMonAn { get; set; }
        public string Hinh { get; set; }
        public double calo { get; set; }

    }
}
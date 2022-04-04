using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class BaiTapModel
    {
        public int IdBT { get; set; }
        public int IdLoai { get; set; }
        public string TenBaiTap { get; set; }
        public string Hinh { get; set; }
        public string NoiDung { get; set; }
        public int SoHiep { get; set; }
        public int SoLanTap { get; set; }
    }
}
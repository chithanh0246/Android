using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    [Table("BaiTap")]
    public class BaiTap
    {
        [Key]
        public int IdBT { get; set; }
        public int IdLoai { get; set; }
        public string TenBaiTap { get; set; }
        public string Hinh { get; set; }
        public string NoiDung { get; set; }
        public int SoHiep { get; set; }
        public int SoLanTap { get; set; }
    }
}

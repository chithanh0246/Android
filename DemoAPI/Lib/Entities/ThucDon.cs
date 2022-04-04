using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    [Table("ThucDon")]
    public class ThucDon
    {
     
        [Key]
        public int IdTD { get; set; }
        public int IdLoai { get; set; }
        public string TenMonAn { get; set; }
        public string Hinh { get; set; }
        public double calo { get; set; }


   
    }
}

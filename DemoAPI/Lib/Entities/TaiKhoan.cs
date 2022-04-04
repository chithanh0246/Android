using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int IdTK { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string HoTen { get; set; }
        public int IdLoai { get; set; }

    }
}

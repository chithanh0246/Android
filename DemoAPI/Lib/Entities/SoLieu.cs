using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    [Table("SoLieu")]
    public class SoLieu
    {
        [Key]
        public int IdSL { get; set; }
        public int ChieuCao { get; set; }
        public int CanNang { get; set; }
        public int IdTK { get; set; }
  
    }
}

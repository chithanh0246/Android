using Lib.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ApplicationDbContext : IdentityDbContext 
    {

        public DbSet<BaiTap> BaiTap { get; set; }
        public DbSet<ThucDon> ThucDon { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<SoLieu> SoLieu { get; set; }

        public ApplicationDbContext()
           : base("DefaultConnection")
        {
        }

    }
}

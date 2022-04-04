using Lib.Data;
using Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        List<TaiKhoan> GetAllTaiKhoans();
    }
    public class TaiKhoanRespository : RepositoryBase<TaiKhoan>, ITaiKhoanRepository
    {
        public TaiKhoanRespository(DbContextFactory factory)
            : base(factory)
        {

        }
        public List<TaiKhoan> GetAllTaiKhoans()
        {
            var query = dataContext.TaiKhoan.AsQueryable();
            return query.ToList();
        }
        public List<TaiKhoan> GetTaiKhoans()
        {
            var query = dataContext.TaiKhoan.Where(p=>p.IdLoai.Equals(2));
            return query.ToList();
        }
        public bool Login(string username, string password)
        {

            var query = dataContext.TaiKhoan.Where(p => p.Email.Equals(username) && p.Pass.Equals(password) && p.IdLoai.Equals(1)).Count() == 1 ? true : false;
            return query;
        }


    }
}

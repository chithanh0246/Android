using Lib.Data;
using Lib.Entities;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class TaiKhoanServices
    {
        private IUnitOfWork unitWork;
        private TaiKhoanRespository taikhoanRespository;
        public TaiKhoanServices()
        {
            var dbContextFactory = new DbContextFactory();
            unitWork = new UnitOfWork(dbContextFactory);
            taikhoanRespository = new TaiKhoanRespository(dbContextFactory);
        }
        public void Save()
        {
            unitWork.Commit();
        }
        public void insertTaiKhoan(TaiKhoan s)
        {
            taikhoanRespository.Add(s);
            Save();
        }
        public void updateTaiKhoan(TaiKhoan s)
        {

            taikhoanRespository.Update(s);
            Save();

        }

        public bool Login(string Email, string pass)
        {
            return taikhoanRespository.Login(Email, pass);
        }

        public List<TaiKhoan> GetAllTaiKhoans()
        {
            return taikhoanRespository.GetAllTaiKhoans();
        }
        public List<TaiKhoan> GetTaiKhoans()
        {
            return taikhoanRespository.GetTaiKhoans();
        }
    }
}

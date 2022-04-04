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
    public class BaiTapServices
    {
        private IUnitOfWork unitWork;
        private BaiTapRespository baiTapRespository;
        public BaiTapServices()
        {
            var dbContextFactory = new DbContextFactory();
            unitWork = new UnitOfWork(dbContextFactory);
            baiTapRespository = new BaiTapRespository(dbContextFactory);
        }
        public void Save()
        {
            unitWork.Commit();
        }

        public List<BaiTap> GetAllBaiTaps()
        {
            return baiTapRespository.GetAllBaiTaps();
        }
        public void updateBaiTap(BaiTap s)
        {
            baiTapRespository.Update(s);
            Save();
        }
        public List<BaiTap> GetBaiTapTC()
        {
            return baiTapRespository.GetBaiTapTC();
        }
        public List<BaiTap> GetBaiTapGC()
        {
            return baiTapRespository.GetBaiTapGC();
        }
    }
}

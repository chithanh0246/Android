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
    public class ThucDonServices
    {
        private IUnitOfWork unitWork;
        private ThucDonRespository thucdonRespository;
        public ThucDonServices()
        {
            var dbContextFactory = new DbContextFactory();
            unitWork = new UnitOfWork(dbContextFactory);
            thucdonRespository = new ThucDonRespository(dbContextFactory);
        }
        public void Save()
        {
            unitWork.Commit();
        }

        public List<ThucDon> GetAllThucDons()
        {
            return thucdonRespository.GetAllThucDons();
        }
        public List<ThucDon> GetThucDonTC()
        {
            return thucdonRespository.GetThucDonTC();
        }
        public List<ThucDon> GetThucDonGC()
        {
            return thucdonRespository.GetThucDonGC();
        }

    }
}

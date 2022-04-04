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
    public class SoLieuServices
    {
        private IUnitOfWork unitWork;
        private SoLieuRespository solieuRespository;
        public SoLieuServices()
        {
            var dbContextFactory = new DbContextFactory();
            unitWork = new UnitOfWork(dbContextFactory);
            solieuRespository = new SoLieuRespository(dbContextFactory);
        }
        public void Save()
        {
            unitWork.Commit();
        }
        public void insertSoLieu(SoLieu s)
        {
            solieuRespository.Add(s);
            Save();
        }
        public void updateSoLieu(SoLieu s)
        {

            solieuRespository.Update(s);
            Save();

        }
        public List<SoLieu> getAllSoLieus()
        {
            return solieuRespository.GetAllSoLieus();
        }
   
       
    }
}

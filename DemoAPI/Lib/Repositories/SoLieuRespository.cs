using Lib.Data;
using Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface ISoLieuRepository : IRepository<SoLieu>
    {
        List<SoLieu> GetAllSoLieus();
    }
    public class SoLieuRespository : RepositoryBase<SoLieu>, ISoLieuRepository
    {
        public SoLieuRespository(DbContextFactory factory)
            : base(factory)
        {

        }
        public List<SoLieu> GetAllSoLieus()
        {
            var query = dataContext.SoLieu.AsQueryable();
            return query.ToList();
        }
      

    }
}

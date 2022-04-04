using Lib.Data;
using Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IThucDonRepository : IRepository<ThucDon>
    {
        List<ThucDon> GetAllThucDons();
    }
    public class ThucDonRespository : RepositoryBase<ThucDon>, IThucDonRepository
    {
        public ThucDonRespository(DbContextFactory factory)
            : base(factory)
        {

        }
        public List<ThucDon> GetAllThucDons()
        {
            var query = dataContext.ThucDon.AsQueryable();
            return query.ToList();
        }
        public List<ThucDon> GetThucDonTC()
        {
            var query = dataContext.ThucDon.Where(p => p.IdLoai.Equals(1));
            return query.ToList();
        }
        public List<ThucDon> GetThucDonGC()
        {
            var query = dataContext.ThucDon.Where(p => p.IdLoai.Equals(2));
            return query.ToList();
        }

    }
}

using Lib.Data;
using Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IBaiTapRepository : IRepository<BaiTap>
    {
        List<BaiTap> GetAllBaiTaps();
    }
    public class BaiTapRespository : RepositoryBase<BaiTap>, IBaiTapRepository
    {
        public BaiTapRespository(DbContextFactory factory)
            : base(factory)
        {

        }
        public List<BaiTap> GetAllBaiTaps()
        {
            var query = dataContext.BaiTap.AsQueryable();
            return query.ToList();
        }
        public List<BaiTap> GetBaiTapTC()
        {
            var query = dataContext.BaiTap.Where(p=>p.IdLoai.Equals(1));
            return query.ToList();
        }
        public List<BaiTap> GetBaiTapGC()
        {
            var query = dataContext.BaiTap.Where(p => p.IdLoai.Equals(2));
            return query.ToList();
        }

    }
}

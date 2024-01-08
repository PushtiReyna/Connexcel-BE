using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.CommonHelpers
{
    public class CommonRepo
    {
        private readonly DBContext _dbContext;

        public CommonRepo(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<UserMst> UserMstList(bool isActive = true, bool isDelete = false)
        {
            return _dbContext.UserMsts.Where(x => x.IsActive == isActive && x.IsDelete == isDelete).AsQueryable();
        }
        public IQueryable<TokenMst> TokenMstList()
        {
            return _dbContext.TokenMsts.AsQueryable();
        }
    }
}

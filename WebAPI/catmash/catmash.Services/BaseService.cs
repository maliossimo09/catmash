using catmash.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace catmash.Services
{
    public class BaseService
    {
        protected AppDbContext _dbContext;
        public BaseService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

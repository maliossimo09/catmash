using catmash.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace catmash.Services
{
    public class ServiceBase
    {
        protected AppDbContext _dbContext;
        public ServiceBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

using catmash.IServices;
using catmash.Models;
using catmash.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace catmash.Services
{
    public class CatService : BaseService, ICatService
    {
        public CatService(AppDbContext dbContext) : base (dbContext)
        {
         
        }

       
    }
}

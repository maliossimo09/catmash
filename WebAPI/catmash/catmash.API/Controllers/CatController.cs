using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catmash.IServices;
using catmash.Models;
using Microsoft.AspNetCore.Mvc;

namespace catmash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private ICatService _catService;

        public CatController(ICatService catService)
        {
            this._catService = catService;
        }

        [HttpGet]
        [Route("cats")]
        public ActionResult<IEnumerable<Cat>> Get()
        {
            return this._catService.GetCatsList().ToList();
        }

        [HttpGet]
        [Route("candidates")]
        public ActionResult<IEnumerable<Cat>> GetForVote()
        {
            return this._catService.GetCatsForVote(2).ToList();
        }

        [HttpPost]
        [Route("vote/{id}")]
        public void Vote(string id)
        {
            this._catService.VoteForCatById(id);
        }

    }
}

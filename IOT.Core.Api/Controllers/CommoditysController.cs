using IOT.Core.IRepository.CommodityRepository;
using IOT.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommoditysController : ControllerBase
    {
       
        private readonly ICommodityRepository _commodityRepository;
       
        public CommoditysController(ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }
        [Route("/api/Commshow")]
        [HttpGet]
        public IActionResult Commshow()
        {
            var list = _commodityRepository.Query();
            return Ok(list
            
               

            );
        }
        [Route("/api/Add")]
        [HttpPost]
        public int Add(Commodity commodity)
        {
            return _commodityRepository.Insert(commodity);
        }
        [Route("/api/Uptstate")] 
        [HttpPost]
        public int Uptstate(int id)
        {
            return _commodityRepository.Uptstate(id);
        }
        [Route("/api/Uptsstate")]
        [HttpPost]
        public int Uptsstate(int id)
        {
            return _commodityRepository.Uptsstate(id);
        }


    }
}

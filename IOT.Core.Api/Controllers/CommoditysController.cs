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
        public IActionResult Commshow(int code=1,int tid=0,string keyname="")
        {
            try
            {
                var list = _commodityRepository.Query(code, tid, keyname);
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/api/BindCommshow")]
        [HttpGet]
        public IActionResult BindCommshow()
        {
            try
            {
                var list = _commodityRepository.BindShowCom();
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/api/Add")]
        [HttpPost]
        public int Add(Commodity commodity)
        {
            try
            {
                int i = _commodityRepository.Insert(commodity);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("/api/Uptstate")] 
        [HttpPost]
        public int Uptstate(int id)
        {
            try
            {
                int i = _commodityRepository.Uptstate(id);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("/api/Uptsstate")]
        [HttpPost]
        public int Uptsstate(int id)
        {
            try
            {
                int i = _commodityRepository.Uptsstate(id);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

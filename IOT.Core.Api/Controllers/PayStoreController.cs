using IOT.Core.IRepository.PayStore;
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
    public class PayStoreController : ControllerBase
    {

        private readonly IPayStoreRepository _payStoreRepository;

        public PayStoreController(IPayStoreRepository payStoreRepository)
        {
            _payStoreRepository = payStoreRepository;
        }
        [HttpGet]
        [Route("/api/ShowPayStore")]
        public IActionResult ShowPayStore()
        {
            List<Model.PayStore> lp = _payStoreRepository.GetPayStores();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lp
            });
        }

        [HttpPut]
        [Route("/api/UptCollection")]
        public int UptCollection()
        {
            int i = _payStoreRepository.UptCollection();
            return i;
        }

        [HttpPut]
        [Route("/api/UptWhether")]
        public int UptWhether()
        {
            int i = _payStoreRepository.UptWhether();
            return i;
        }

    }
}

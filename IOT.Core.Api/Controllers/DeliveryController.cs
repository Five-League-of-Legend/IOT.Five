using IOT.Core.IRepository.Delivery;
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
    public class DeliveryController : ControllerBase
    {

        private readonly IDeliveryRepository _delivery;

        public DeliveryController(IDeliveryRepository delivery)
        {
            _delivery = delivery;
        }

        //显示
        [Route("/api/DeliveryShow")]
        [HttpGet]
        public IActionResult DeliveryShow()
        {
            var ls = _delivery.ShowDelivery();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //删除
        [HttpPost]
        [Route("/api/DeliveryDel")]
        public int DeliveryDel(string ids)
        {
            return _delivery.DelDelivery(ids);
        }

        //修改
        [HttpPost]
        [Route("/api/DeliveryUpt")]
        public int DeliveryUpt(IOT.Core.Model.Delivery a)
        {
            return _delivery.UptDelivery(a);
        }

    }
}

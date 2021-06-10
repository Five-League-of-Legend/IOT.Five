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

        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryController(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        [HttpGet]
        [Route("/api/ShowDelivery")]
        public IActionResult ShowDelivery(int warehouseId)
        {
            List<IOT.Core.Model.Delivery> ld = _deliveryRepository.Query();
            //查找
            if (warehouseId != 0)
            {
                ld = ld.Where(x => x.WarehouseId.Equals(warehouseId)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = ld
            });


        }

        [HttpPost]
        [Route("/api/AddDelivery")]
        public int AddDelivery(IOT.Core.Model.Delivery delivery)
        {
            int i = _deliveryRepository.Insert(delivery);
            return i;

        }

        [HttpDelete]
        [Route("/api/DelDelivery")]
        public int DelDelivery(string ids)
        {
            int i = _deliveryRepository.Delete(ids);
            return i;

        }


        [HttpPut]
        [Route("/api/UptDelivery")]
        public int UptDelivery([FromForm] IOT.Core.Model.Delivery delivery)
        {
            int i = _deliveryRepository.Update(delivery);
            return i;

        }


        [HttpGet]
        [Route("/api/FtDelivery")]
        public IActionResult FtWarehouse(int id)
        {
            List<IOT.Core.Model.Delivery> ld = _deliveryRepository.Query();
            IOT.Core.Model.Delivery delivery = ld.FirstOrDefault(x => x.DeliveryId.Equals(id));
            return Ok(new
            {
                msg = "",
                code = 0,
                data = delivery
            });

        }

    }
}

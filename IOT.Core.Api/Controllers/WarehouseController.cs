using IOT.Core.IRepository.Warehouse;
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
    public class WarehouseController : ControllerBase
    {

        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        [Route("/api/ShowWarehouse")]
        public IActionResult ShowWarehouse()
        {
            List<Model.Warehouse> lw = _warehouseRepository.Query();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lw
            });
        }

        [HttpPost]
        [Route("/api/AddWarehouse")]
        public int AddWarehouse([FromForm] IOT.Core.Model.Warehouse warehouse)
        {
            int i = _warehouseRepository.Insert(warehouse);
            return i;
        }
        [HttpDelete]
        [Route("/api/DelWarehouse")]
        public int DelWarehouse(string ids)
        {
            int i = _warehouseRepository.Delete(ids);
            return i;
        }
        [HttpPost]
        [Route("/api/UptWarehouse")]
        public int UptWarehouse([FromForm] IOT.Core.Model.Warehouse warehouse)
        {
            int i = _warehouseRepository.Update(warehouse);
            return i;
        }

        [HttpPut]
        [Route("/api/UptWarehouseState")]
        public int UptWarehouseState(int id)
        {
            int i = _warehouseRepository.UptState(id);
            return i;
        }

        [HttpGet]
        [Route("/api/FtWarehouse")]
        public IActionResult FtWarehouse(int id)
        {
            List<IOT.Core.Model.Warehouse> lw = _warehouseRepository.Query();
            IOT.Core.Model.Warehouse warehouse = lw.FirstOrDefault(x => x.WarehouseId.Equals(id));
            return Ok(new
            {
                msg = "",
                code = 0,
                data = warehouse
            });

        }

    }
}

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

        // 依赖注入
        private readonly IWarehouseRepository _warehouse;
        public WarehouseController(IWarehouseRepository warehouse)
        {
            _warehouse = warehouse;
        }

        // 显示
        [Route("/api/WarehouseShow")]
        [HttpGet]
        public IActionResult WarehouseShow()
        {
            var ls = _warehouse.ShowWarehouse();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //添加
        [HttpPost]
        [Route("/api/WarehouseAdd")]
        public int WarehouseAdd(IOT.Core.Model.Warehouse a)
        {
            int i = _warehouse.AddWarehouse(a);
            return i;
        }

        //删除
        [HttpPost]
        [Route("/api/WarehouseDel")]
        public int WarehouseDel(string ids)
        {
            return _warehouse.DelWarehouse(ids);
        }

        //修改
        [HttpPost]
        [Route("/api/WarehouseUpt")]
        public int WarehouseUpt(IOT.Core.Model.Warehouse a)
        {
            return _warehouse.UptWarehouse(a);
        }

    }
}

using IOT.Core.IRepository.Store_Configuration;
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
    public class Store_ConfigurationController : ControllerBase
    {

        private readonly IStore_ConfigurationRepository _store_ConfigurationRepository;
        public Store_ConfigurationController(IStore_ConfigurationRepository store_ConfigurationRepository)
        {
            _store_ConfigurationRepository = store_ConfigurationRepository;
        }
        [HttpPost]
        [Route("api/InsertPic")]
        public int InsertPic(Model.Store_Configuration Model)
        {
            int i = _store_ConfigurationRepository.InsertPic(Model);
            return i;
        }

    }
}

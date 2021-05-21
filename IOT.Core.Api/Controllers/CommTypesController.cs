using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Model;
using IOT.Core.IRepository.CommType;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommTypesController : ControllerBase
    {
        private readonly ICommTypeRepository _commTypeRepository;
        public CommTypesController(ICommTypeRepository commTypeRepository)
        {
            _commTypeRepository = commTypeRepository;
        }
        [Route("api/Show")]
        [HttpGet]
        public List<IOT.Core.Model.CommType> Show(int tid=0)
        {

            return _commTypeRepository.Query(tid);
        }
        [Route("api/Add")]
        [HttpPost]
        public int Add(IOT.Core.Model.CommType c)
        {
            return _commTypeRepository.Insert(c);
        }
        [Route("api/Del")]
        [HttpPost]
        public int Del(string ids)
        {
            
            return _commTypeRepository.Delete(ids);
        }
        [Route("api/UptState")]
        [HttpGet]
        public List<Model.CommType> Upts(int id)
        {
            return _commTypeRepository.UptState(id);
        }  
        [Route("api/Uptss")]
        [HttpPost]
        public int Uptss(Model.CommType c)
        {
            return _commTypeRepository.Uptss(c);
        }






    }
}

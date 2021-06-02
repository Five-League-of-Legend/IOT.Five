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
        public IActionResult Show(string tname="", int state=0)
        {
            var list = _commTypeRepository.Query(tname,state);
            if (!string.IsNullOrEmpty(tname))
            {
                list = list.Where(x => x.TName.Contains(tname)).ToList();
            }
            if (state!=0)
            {
                list = list.Where(x => x.State.Equals(state)).ToList();
            }
            return Ok(list);
           
        }
        [Route("api/Bang")]
        [HttpGet]
        public List<Model.CommType> Bang(int ParentId)
        {
            return _commTypeRepository.Bang(ParentId);
        }
        [Route("api/Add")]
        [HttpPost]
        public int Add(IOT.Core.Model.CommType c)
        {
            return _commTypeRepository.Insert(c);
        }
        [Route("api/Del")]
        [HttpGet]
        public int Del(string ids)
        {
            int i = _commTypeRepository.Delete(ids);
            return i;
        }
        [Route("api/UptState")]
        [HttpGet]
        public int Upts(int id)
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

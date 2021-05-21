using IOT.Core.IRepository.Specification;
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
    public class SpecificationsController : ControllerBase
    {
        private readonly ISpecificationRepository _specificationRepository;
        public SpecificationsController(ISpecificationRepository specificationRepository)
        {
            _specificationRepository = specificationRepository;
        }
        [HttpGet]
        [Route("api/Showw")]
        public List<Model.Specification> Showw(string commspec = "")
        {
            return _specificationRepository.Query(commspec);
        }
        [HttpPost]
        [Route("api/Insert")]
        public int Insert(Model.Specification Model)
        {
            return _specificationRepository.Insert(Model);
        }
        [HttpPost]
        [Route("api/Delete")]
        public int Delete(string ids)
        {
            return _specificationRepository.Delete(ids);
        }



    }
}

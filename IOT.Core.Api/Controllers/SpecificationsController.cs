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
        [Route("/api/SpeciShoww")]
        public IActionResult SpeciShoww(string commspec = "")
        {
            List<Model.Specification> specifications = _specificationRepository.Query(commspec);
            return Ok(new { code=0,msg="",data= specifications });
        }
        [HttpPost]
        [Route("/api/SpeciInsert")]
        public int SpeciInsert([FromForm]Model.Specification Model)
        {
            return _specificationRepository.Insert(Model);
        }
        [HttpPost]
        [Route("/api/SpeciDelete")]
        public int SpeciDelete(string ids)
        {
            return _specificationRepository.Delete(ids);
        }
        [HttpGet]
        [Route("/api/SpeciUptState")]
        public List<Model.Specification> SpeciUptState(int id)
        {
            return _specificationRepository.UptState(id);
        }
        [HttpPost]
        [Route("/api/SpeciUptss")]
        public int SpeciUptss(Model.Specification c)
        {
            return _specificationRepository.Uptss(c);
        }
        [HttpPost]
        [Route("/api/SpeciDeletes")]
        public int SpeciDeletes(string id)
        {

            return _specificationRepository.Deletes(id);

        }



    }
}

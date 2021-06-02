using IOT.Core.IRepository.Com_Comment;
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
    public class Com_CommentsController : ControllerBase
    {


        private readonly ICom_CommentRepository _com_CommentRepository;

        public Com_CommentsController(ICom_CommentRepository com_CommentRepository)
        {
            _com_CommentRepository = com_CommentRepository;
        }
        
        [HttpGet]
        [Route("/api/Query")]
        public IActionResult Query(string commentcontent = "", int commodityid = 0, int userid = 0)
        {
            return Ok(_com_CommentRepository.Query(commentcontent, commodityid, userid));
        }
        [HttpPost]
        [Route("/api/Insert")]
        public int Insert(Model.Com_Comment Model)
        {
            return _com_CommentRepository.Insert(Model);
        }
        [HttpPost]
        [Route("/api/Delete")]
        public int Delete(string ids)
        {
            return _com_CommentRepository.Delete(ids);
        }
        [HttpPost]
        [Route("/api/Uptssss")]
        public int Upt(Model.Com_Comment cs)
        {
            return _com_CommentRepository.Upt(cs);
        }



    }
}

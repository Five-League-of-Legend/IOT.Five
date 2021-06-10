using IOT.Core.IRepository.Com_Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT.Core.Api.Controllers
{
    public enum Selectpage
    {
        全部 = 1,
        今天 = 2,
        昨天 = 3,
        最近七天 = 4,
        最近30天 = 5,
        本月 = 6,
        本年 = 7,
    }
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
        public IActionResult Query(string commentcontent = "", int commodityid = 0, int userid = 0,int page=1,string sdate="")
        {
            List<Model.Com_Comment> lc = _com_CommentRepository.Query(commentcontent, commodityid, userid);
            Selectpage sp = (Selectpage)page;
            switch (sp)
            {
                case Selectpage.全部:
                    if (!string.IsNullOrEmpty(sdate))
                    {
                        lc = lc.Where(x => x.CommentTime.Date == Convert.ToDateTime(sdate).Date).ToList();
                    }
                    break;
                case Selectpage.今天:
                    lc = lc.Where(x => x.days == 0).ToList();
                    break;
                case Selectpage.昨天:
                    lc = lc.Where(x => x.days == 1).ToList();
                    break;
                case Selectpage.最近七天:
                    lc = lc.Where(x => x.days == 7).ToList();
                    break;
                case Selectpage.最近30天:
                    lc = lc.Where(x => x.days == 30).ToList();
                    break;
                case Selectpage.本月:
                    lc = lc.Where(x => x.CommentTime.Year==DateTime.Now.Year&&x.CommentTime.Month==DateTime.Now.Month).ToList();
                    break;
                case Selectpage.本年:
                    lc = lc.Where(x => x.CommentTime.Year==DateTime.Now.Year).ToList();
                    break;
                default:
                    break;
            }
            return Ok(lc);
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

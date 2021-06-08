using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.WorkBench;

namespace IOT.Core.Api.Controllers
{
    public enum WorkPage
    {
        实时=1,
        昨日=2,
        近7天=3,
        近30天=4
    }
    [Route("api/[controller]")]
    [ApiController]
    public class WorkBenchController : ControllerBase
    {
        private readonly IWorkBenchRepository _workBenchRepository;

        public WorkBenchController(IWorkBenchRepository workBenchRepository)
        {
            _workBenchRepository = workBenchRepository;
        }
        [HttpGet]
        [Route("/api/GetWork")]
        public IActionResult GetWork(int page=1)
        {
            Model.WorkBench wb = new Model.WorkBench();
            List<Model.OrderInfo> orders = _workBenchRepository.OrderSelect();
            List<Model.Lognote> lognotes = _workBenchRepository.lognotesSelect();
            wb.Waitdeliver = orders.Where(x => x.OrderState.Equals(2)).Count();
            wb.Refunding = orders.Where(x => x.OrderState.Equals(5)).Count();
            WorkPage wp = (WorkPage)page;
            switch (wp)
            {
                case WorkPage.实时:
                    orders = orders.Where(x => x.StartTime.Date.Equals(DateTime.Now.Date)).ToList();
                    wb.Ordernum = orders.Count();
                    orders = orders.Where(x => x.PayState == 1).ToList();
                    int num1 = orders.Count();
                    wb.Payprice = orders.Sum(x => x.AmountPaid);
                    lognotes = lognotes.Where(x => x.Operationtime.Date.Equals(DateTime.Now.Date)).ToList();
                    lognotes = lognotes.Distinct().ToList();
                    wb.Visitornum = lognotes.Count();
                    if (wb.Payprice==0)
                    {
                        wb.Customerunit = 0;
                    }
                    else
                    {
                        wb.Customerunit = wb.Payprice / num1;
                    }
                    break;
                case WorkPage.昨日:
                    orders = orders.Where(x => x.days==1).ToList();
                    wb.Ordernum = orders.Count();
                    orders = orders.Where(x => x.PayState == 1).ToList();
                    int num2 = orders.Count();
                    wb.Payprice = orders.Sum(x => x.AmountPaid);
                    lognotes = lognotes.Where(x => x.days==1).ToList();
                    lognotes = lognotes.Distinct().ToList();
                    wb.Visitornum = lognotes.Count();
                    if (wb.Payprice == 0)
                    {
                        wb.Customerunit = 0;
                    }
                    else
                    {
                        wb.Customerunit = wb.Payprice / num2;
                    }
                    break;
                case WorkPage.近7天:
                    orders = orders.Where(x => x.days<=7).ToList();
                    wb.Ordernum = orders.Count();
                    orders = orders.Where(x => x.PayState == 1).ToList();
                    int num3 = orders.Count();
                    wb.Payprice = orders.Sum(x => x.AmountPaid);
                    lognotes = lognotes.Where(x => x.days<=7).ToList();
                    lognotes = lognotes.Distinct().ToList();
                    wb.Visitornum = lognotes.Count();
                    if (wb.Payprice == 0)
                    {
                        wb.Customerunit = 0;
                    }
                    else
                    {
                        wb.Customerunit = wb.Payprice / num3;
                    }
                    break;
                case WorkPage.近30天:
                    orders = orders.Where(x => x.days<=30).ToList();
                    wb.Ordernum = orders.Count();
                    orders = orders.Where(x => x.PayState == 1).ToList();
                    int num4 = orders.Count();
                    wb.Payprice = orders.Sum(x => x.AmountPaid);
                    lognotes = lognotes.Where(x => x.days<=30).ToList();
                    lognotes = lognotes.Distinct().ToList();
                    wb.Visitornum = lognotes.Count();
                    if (wb.Payprice == 0)
                    {
                        wb.Customerunit = 0;
                    }
                    else
                    {
                        wb.Customerunit = wb.Payprice / num4;
                    }
                    break;
                default:
                    break;
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = wb
            });
        }
    }
}

using IOT.Core.IRepository.OrderInfos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderInfosController : ControllerBase
    {
        private readonly IOrderInfosRepository _orderInfoRepository;

        public OrderInfosController(IOrderInfosRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }



        [HttpGet]
        [Route("/api/GetListOrderInfo")]
        public IActionResult GetListOrderInfo(int bid=0,string name = "",int sendway = 0 ,string state = "", string end = "", int tui = 0, int dingt = 0, int uid = 0, string cname = "", string ziti = "")
        {
            try
            {
                List<IOT.Core.Model.OrderInfos> list = _orderInfoRepository.GetOrderInfos(name, sendway, state, end, tui, dingt, uid, cname, ziti);
                if (bid==0&&name==""&&sendway==0&&state==""&&end==""&&tui==0&&dingt==0&&uid==0&& cname==""&&ziti=="")
                {
                    return Ok(new
                    {
                        msg = "",
                        code = 0,
                        data = list
                    });
                }else{
                    if (bid==1)
                    {
                        list = list.Where(x => x.Ordernumber.Contains(name)).ToList();
                    }
                    if (bid == 2)
                    {
                        list = list.Where(x => x.UserName.Contains(name)).ToList();
                    }
                    if (bid == 3)
                    {
                        list = list.Where(x => x.Phone.Contains(name)).ToList();
                    }

                    if (sendway != 0)
                    {
                        list = list.Where(x => x.SendWay == sendway).ToList();
                    }
                    if (!string.IsNullOrEmpty(state))
                    {
                        list = list.Where(x => x.StartTime >= Convert.ToDateTime(end)).ToList();
                    }
                    if (!string.IsNullOrEmpty(end))
                    {
                        list = list.Where(x => x.StartTime <=Convert.ToDateTime(end)).ToList();
                    }
                    if (tui != 0)
                    {
                        list = list.Where(x => x.OrderState == tui).ToList();
                    }
                    if (dingt != 0)
                    {
                        list = list.Where(x => x.OrderState == dingt).ToList();
                    }
                    if (uid != 0)
                    {
                        list = list.Where(x => x.UserId == uid).ToList();
                    }
                    if (!string.IsNullOrEmpty(cname))
                    {
                        list = list.Where(x => x.CommodityName.Contains(cname)).ToList();
                    }
                    if (!string.IsNullOrEmpty(ziti))
                    {
                        list = list.Where(x => x.Address.Contains(ziti)).ToList();
                    }
                    return Ok(new
                    {
                        msg = "",
                        code = 0,
                        data = list
                    });
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
            
        }
       [HttpGet]
        [Route("/api/GetOrderInfo")]
       //[HttpGet("/api/GetOrderInfo"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetOrderInfo()
        {
            try
            {
                List<Model.OrderInfos> list = _orderInfoRepository.Query();
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = list
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("/api/getnum")]

        public IActionResult getnum()
        {
            try
            {
                List<Model.v_OrderInfo> list = _orderInfoRepository.getnum();
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = list
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptOrderInfoRemark")]
        
        public int UptRemark([FromForm]Model.OrderInfos Model)
        {
            try
            {
                int i = _orderInfoRepository.UptRemark(Model);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptOrderInfoSendWay")]
        
        public int UptSendWay([FromForm]Model.OrderInfos Model)
        {
            try
            {
                int i = _orderInfoRepository.UptSendWay(Model);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptOrderInfoOrderState")]
        
        public int UptOrderState([FromForm]Model.OrderInfos Model)
        {
            try
            {
                int i = _orderInfoRepository.UptOrderState(Model);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("/api/insert")]

        public int insert(Model.OrderInfos orderInfo)
        {
            try
            {
                int i = _orderInfoRepository.insert(orderInfo);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

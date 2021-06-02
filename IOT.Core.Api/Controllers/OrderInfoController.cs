using IOT.Core.IRepository.OrderInfo;
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
    public class OrderInfoController : ControllerBase
    {
        private readonly IOrderInfoRepository _orderInfoRepository;
        private readonly IOrderCommentRepository _orderCommentRepository;
        private readonly IOrderDelivery _orderDelivery;

        public OrderInfoController(IOrderInfoRepository orderInfoRepository, IOrderCommentRepository orderCommentRepository, IOrderDelivery orderDelivery)
        {
            _orderInfoRepository = orderInfoRepository;
            _orderCommentRepository = orderCommentRepository;
            _orderDelivery = orderDelivery;
        }

        /// <summary>
        /// 显示订单
        /// </summary>
        /// <param name="searchType">查找类型 订单号 买家姓名 买家电话</param>
        /// <param name="searchContent">根据类型判断 查询条件</param>
        /// <param name="sTime">起始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="refundStatus">退款状态</param>
        /// <param name="orderState">订单状态</param>
        /// <param name="userId">用户ID</param>
        /// <param name="CommodityName">商品名称</param>
        /// <param name="SendWay">自提点</param>
        /// <param name="TimeType">时间类型</param>
        /// <param name="setimeArr">开始时间和结束时间</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowViewOrderInfo")]
        public IActionResult GetShowViewOrderInfo(int timeType=-1,string setimeArr="",int searchType = -1, string searchContent = "", string sTime = "", string eTime = "", int refundStatus = -1, int orderState = -1, int userId = -1, string CommodityName = "", int SendWay = -1)
        {
            var ls = _orderInfoRepository.ShowViewOrderInfo(searchType, searchContent, sTime, eTime, refundStatus, orderState, userId, CommodityName, SendWay);

            if (timeType!=-1&timeType!=0)
            {
                if (setimeArr != "" & setimeArr != null)
                {
                    switch (timeType)
                    {
                        case 1:
                            ls = ls.Where(m => m.StartTime == Convert.ToDateTime(setimeArr)).ToList();
                            break;
                    }
                }              
            }
            

            return Ok(ls);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptOrderInfo")]
        public int UptOrderInfo([FromForm]Model.OrderInfo orderInfo)
        {
            return _orderInfoRepository.UptOrderInfo(orderInfo);
        }

        /// <summary>
        /// 统计订单
        /// </summary>
        /// <param name="sum">订单数量</param>
        /// <param name="payment">待付款</param>
        /// <param name="deliver">待发货</param>
        /// <param name="evaluate">待评价</param>
        /// <param name="safeguard">维权中  66</param>
        /// <param name="today">今日下单量</param>
        /// <param name="figure">今日订单金额</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetStatisticsOrder")]
        public IActionResult GetStatisticsOrder()
        {
            string[] ss = _orderInfoRepository.StatisticsOrder().Split('+');

            string[] arr = ss[0].Split(',');
            string[] arr1 = ss[1].Split(',');

             Array.Reverse(arr1);

            return Ok(new
            {
                Sum = arr[0],
                Payment = arr[1],
                Deliver = arr[2],
                Evaluate = arr[3],
                Safeguard = arr[4],
                Today = arr[5],
                Figure = arr[6],
                Num1=arr1[0],
                Num2=arr1[1],
                Num3=arr1[2],
                Num4=arr1[3],
                Num5=arr1[4]
            });
        }



        /// <summary>
        /// 评价管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowOrderCom")]
        public IActionResult GetShowOrderCom()
        {
            List<Model.ViewOrderComAndCom_Com> ls = _orderCommentRepository.ShowOrderCom();
            return Ok(ls);
        }


        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="orderComment"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DelOrderCom")]
        public int DelOrderCom(int id)
        {
            int i = _orderCommentRepository.DelOrderCom(id);

            return i;
        }


        /// <summary>
        /// 修改显示状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptOrderCom")]
        public int UptOrderCom([FromForm]Model.OrderComment orderComment)
        {
            int i = _orderCommentRepository.UptOrderCom(orderComment);

            return i;
        }


        /// <summary>
        /// 订单配送
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowOrderDelivery")]
        public IActionResult GetShowOrderDelivery()
        {
            List<Model.ViewOrderUsersCommodity> ls = _orderDelivery.ShowOrderDelivery();
            return Ok(ls);
        }

    }
}

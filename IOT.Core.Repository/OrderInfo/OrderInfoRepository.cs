using IOT.Core.Common;
using IOT.Core.IRepository.OrderInfo;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderInfo
{
    public class OrderInfoRepository : IOrderInfoRepository
    {

        /// <summary>
        /// 显示表单
        /// </summary>
        /// <param name="searchType">查找类型  1订单号 2买家姓名 3买家电话</param>
        /// <param name="searchContent">根据类型判断 查询条件</param>
        /// <param name="sTime">起始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="refundStatus">退款状态</param>
        /// <param name="orderState">订单状态 1代付款 2代发货 3已取消(24小时内未发货) 4已发货 5 已退款 6退款中 7待评价 8已完成(评价后) 9已删除 10一键退货 11拼团中</param>
        /// <param name="userId">用户ID</param>
        /// <param name="CommodityName">商品名称</param>
        /// <param name="SendWay">自提点</param>
        /// <returns></returns>
        public List<ViewOrderInfoAndCommodity> ShowViewOrderInfo(int searchType, string searchContent, string sTime, string eTime, int refundStatus, int orderState, int userId, string commodityName, int sendWay)
        {
            try
            {
                string sql = $" select a.*," +
                  $"b.CommodityId,b.CommodityName,b.CommodityPic,b.ShopPrice,b.ShopNum,b.SendAddress," +
                  $"c.UserId,c.UserName,c.LoginName,c.Phone,c.Address," +
                  $"d.ColonelName,d.Region " +
                  $"from orderInfo a join commodity b on a.CommodityId = b.CommodityId join users c  on a.UserId = c.UserId join colonel d on c.ColonelID = d.ColonelID where 1 = 1 ";

                if (searchType == 1)//1订单号
                {
                    if (searchContent != "") { sql += $" and a.Orderid = {searchContent} "; }
                }
                else if (searchType == 2)//2买家姓名
                {
                    if (searchContent != "") { sql += $" and c.UserName like '%{searchContent}%' "; }
                }
                else if (searchType == 3)//3买家电话
                {
                    if (searchContent != "") { sql += $" and c.Phone = {searchContent} "; }
                }

                if (sTime != null & sTime != "") { sql += $" and StartTime >= '{sTime}' "; }
                if (eTime != null & eTime != "") { sql += $" and StartTime <= '{eTime}' "; }
                if (refundStatus != -1& refundStatus != 0)
                {
                    sql += $" and OrderState = {refundStatus} ";
                }
                if (orderState != 0 & orderState != -1) { sql += $" and OrderState = {orderState} "; }
                if (userId != 0 & userId != -1) { sql += $" and a.UserId = {userId} "; }
                if (commodityName != null & commodityName != "") { sql += $" and b.CommodityName like '%{commodityName}%' "; }
                if (sendWay != -1) { sql += $" and a.SendWay = {sendWay} "; }
               

                return DapperHelper.GetList<ViewOrderInfoAndCommodity>(sql);

            }
            catch (Exception)
            {

                throw;
            }

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
        public string StatisticsOrder()
        {
            try
            {
                int sum = Convert.ToInt32(DapperHelper.Exescalar(" select count(*) from OrderInfo "));
                int payment = Convert.ToInt32(DapperHelper.Exescalar(" select count(*) from OrderInfo where orderState = 1 "));
                int deliver = Convert.ToInt32(DapperHelper.Exescalar(" select count(*) from OrderInfo where orderState = 2 "));
                int evaluate = Convert.ToInt32(DapperHelper.Exescalar(" select count(*) from OrderInfo where orderState = 7 "));
                int safeguard = Convert.ToInt32(DapperHelper.Exescalar(" select count(*) from OrderInfo where orderState = 66 "));
                int today = Convert.ToInt32(DapperHelper.Exescalar(" select COUNT(*) from orderInfo where DATE(StartTime) = CURDATE() "));
                int figure = Convert.ToInt32(DapperHelper.Exescalar(" select SUM(OrderPrice) from orderInfo where DATE(StartTime) = CURDATE() "));
                List<OrderInfoCommodityPrice> list = DapperHelper.GetList<OrderInfoCommodityPrice>("select  OrderPrice from OrderInfo ORDER BY Orderid desc LIMIT 5");

                string strlist = "";


                foreach (var item in list)
                {
                    strlist += item.OrderPrice + ",";
                }

                string ss = sum + "," + payment + "," + deliver + "," + evaluate + "," + safeguard + "," + today + "," + figure;

                return ss + "+" + strlist.TrimEnd(',');
            }
            catch (Exception)
            {

                throw;
            }
      
        }


        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UptOrderInfo(Model.OrderInfo a)
        {
            try
            {
                string sql = $" update orderInfo set CommodityId={a.CommodityId},UserId={a.UserId},SendWay={a.SendWay},OrderState={a.OrderState},Remark='{a.Remark}',CommodityPrice={a.CommodityPrice},DistributionCosts={a.DistributionCosts},OrderPrice={a.OrderPrice},CouponPrice={a.CouponPrice},AmountPaid={a.AmountPaid},StartTime='{a.StartTime}' where Orderid = {a.Orderid} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        
        }

    }
}

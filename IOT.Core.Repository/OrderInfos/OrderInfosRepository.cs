using IOT.Core.Common;
using IOT.Core.IRepository.OrderInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderInfos
{
    public  class OrderInfosRepository : IOrderInfosRepository
    {
        /// <summary>
        /// 三表联查各种数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="state"></param>
        /// <param name="end"></param>
        /// <param name="tui"></param>
        /// <param name="dingt"></param>
        /// <param name="uid"></param>
        /// <param name="cname"></param>
        /// <param name="ziti"></param>
        /// <returns></returns>
        public List<Model.OrderInfos> GetOrderInfos(string name, int sendway, string state, string end, int tui, int dingt, int uid, string cname, string ziti)
        {

            string sql = $@"select b.CommodityName ,b.CommodityPic ,b.ShopPrice ,b.SId ,
             c.NickName ,c.UserName ,c.Phone ,c.Address ,a.* from OrderInfo a
            join Commodity b on a.CommodityId = b.CommodityId
            join Users c on a.UserId = c.UserId 
            join Colonel d on c.ColonelID=d.ColonelID";
            return DapperHelper.GetList<Model.OrderInfos>(sql);
        }

        public int Delete(string ids)
        {
            string sql = $@"delete from OrderInfo where Orderid={ids}";
            return DapperHelper.Execute(sql);
        }



        public int Insert(Model.OrderInfos Model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询订单表
        /// </summary>
        /// <returns></returns>
        public List<Model.OrderInfos> Query()
        {
            string sql = $@"select a.*,b.*,c.*,d.*
            from OrderInfo a
            join Commodity b on a.CommodityId = b.CommodityId
            join Users c on a.UserId = c.UserId 
            join Colonel d on c.ColonelID=d.ColonelID";
            return DapperHelper.GetList<Model.OrderInfos>(sql);
        }

        public int UptRemark(Model.OrderInfos Model)
        {
            string sql = $"UPDATE OrderInfo SET Remark='{Model.Remark}' where Orderid={Model.Orderid}";
            return DapperHelper.Execute(sql);
        }

        public int UptSendWay(Model.OrderInfos Model)
        {
            string sql = $"UPDATE OrderInfo SET SendWay='{Model.SendWay}' where Orderid={Model.Orderid}";
            return DapperHelper.Execute(sql);
        }

        public int UptOrderState(Model.OrderInfos Model)
        {
            string sql = $"UPDATE OrderInfo SET OrderState='{Model.OrderState}' where Orderid={Model.Orderid}";
            return DapperHelper.Execute(sql);
        }

        public int insert(Model.OrderInfos orderInfo)
        {
            string sql = $"SELECT CONCAT(DATE_FORMAT(now(), '%Y%m%d%H%i%s'),lpad(round(round(rand(),4)*1000),4,'0'))";
            var num = DapperHelper.Exescalar(sql);
            string sqla = $"SELECT CONCAT(DATE_FORMAT(now(), '%Y%m%d%H%i%s'),lpad(round(round(rand(),4)*1000),4,'0'))";
            var nums = DapperHelper.Exescalar(sqla);
            string sqls = $"insert INTO OrderInfo values(NULL,'{num}','{nums}','{orderInfo.CommodityId}','{orderInfo.UserId}','{orderInfo.SendWay}','{orderInfo.OrderState}','{orderInfo.Remark}','{orderInfo.CommodityPrice}','{orderInfo.DistributionCosts}','{orderInfo.OrderPrice}','{orderInfo.CouponPrice}','{orderInfo.AmountPaid}','{orderInfo.StartTime}')";
            return DapperHelper.Execute(sqls);
        }

        public List<Model.v_OrderInfo> getnum()
        {
            string sql = $"select * from  v_OrderInfo";
            return DapperHelper.GetList<Model.v_OrderInfo>(sql);
        }

    }
}

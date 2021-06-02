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
    public class OrderCommentRepository : IOrderCommentRepository
    {


        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="orderComment"></param>
        /// <returns></returns>
        public int DelOrderCom(int id)
        {
            try
            {
                string sql = $" delete from OrderComment where Commentid = {id} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
       
        }

        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public List<ViewOrderComAndCom_Com> ShowOrderCom()
        {
            try
            {
                string sql = " select a.*,b.*,c.CommodityName,c.CommodityPic from ordercomment a join com_comment b on a.Com_CommentId = b.Com_CommentId join Commodity c on b.CommodityId=c.CommodityId  ";
                return DapperHelper.GetList<ViewOrderComAndCom_Com>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        /// <summary>
        /// 修改显示状态
        /// </summary>
        /// <returns></returns>
        public int UptOrderCom(OrderComment orderComment)
        {
            try
            {
                string sql = $" update OrderComment set State=ABS(State-1) where Commentid = {orderComment.Commentid}  ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
       
        }
    }
}

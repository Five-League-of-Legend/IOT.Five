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
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        public List<ViewOrderComAndCom_Com> ShowOrderCom()
        {
            string sql = " select * from ordercomment a join com_comment b on a.Com_CommentId = b.Com_CommentId" ;
            return DapperHelper.GetList<ViewOrderComAndCom_Com>(sql);
        }


        /// <summary>
        /// 修改显示状态
        /// </summary>
        /// <returns></returns>
        public int UptOrderCom(OrderComment orderComment)
        {
            string sql = $" update OrderComment set State=ABS(State-1) where Commentid = {orderComment.Commentid}  ";
            return DapperHelper.Execute(sql);
        }
    }
}

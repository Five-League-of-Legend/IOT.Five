using IOT.Core.Common;
using IOT.Core.IRepository.Com_Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Com_Comment
{
    public class Com_CommentRepository : ICom_CommentRepository
    {
        public int Delete(string ids)
        {
            try
            {
                string sql = $"delete from Com_Comment where Com_CommentId={ids}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public int Insert(Model.Com_Comment Model)
        {
            try
            {
                string sql = $"insert into Com_Comment values(null,{Model.CommodityId},{Model.UserId},{Model.CommGrade},{Model.SeverGrade},'{Model.CommentContent}','{Model.RevertContent}','{Model.CommentPic}','{Model.CommentTime}')";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Model.Com_Comment> Query(string commentcontent="",int commodityid=0,int userid=0)
        {
            try
            {
                string sql = $"select * from Com_Comment a join Commodity b on a.CommodityId=b.CommodityId join Users c on a.UserId=c.UserId where 1=1";
                if (!string.IsNullOrEmpty(commentcontent))
                {
                    sql += $" and CommentContent like '%{commentcontent}%'";
                }
                if (commodityid != 0)
                {
                    sql += $"  and CommodityId ={commodityid}";
                }
                if (userid != 0)
                {
                    sql += $"  and UserId ={userid}";
                }
                return DapperHelper.GetList<Model.Com_Comment>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public int Upt(Model.Com_Comment cs)
        {
            try
            {
            string sql = $"update Com_Comment set RevertContent='{cs.RevertContent}' where com_CommentId={cs.Com_CommentId}";
            return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}

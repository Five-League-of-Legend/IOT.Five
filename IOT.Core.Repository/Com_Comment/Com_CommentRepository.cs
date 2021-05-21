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
            string sql = $"delete from Com_Comment where Com_CommentId={ids}";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Com_Comment Model)
        {
            string sql = $"insert into Com_Comment values(null,{Model.CommodityId},{Model.UserId},{Model.CommGrade},{Model.SeverGrade},'{Model.CommentContent}','{Model.RevertContent}','{Model.CommentPic}','{Model.CommentTime}')";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Com_Comment> Query(string commentcontent="",int commodityid=0,int userid=0)
        {
            string sql = $"select * from Com_Comment a join Commodity b on a.CommodityId=b.CommodityId join Users c on a.UserId=c.UserId where 1=1";
            if (!string.IsNullOrEmpty(commentcontent))
            { 
                sql += $" and Com_Comment like '%{commentcontent}%'";
            }
            if (commodityid!=0)
            {
                sql += $"  where CommodityId ={commodityid}";
            }
            if (userid!=0)
            {
                sql += $"  where UserId ={userid}";
            }
            return DapperHelper.GetList<Model.Com_Comment>(sql);
        }

    }
}

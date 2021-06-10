using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 商品评论
    /// </summary>
    public class Com_Comment
    {
        public int Com_CommentId   { get; set; }
        public int CommodityId     { get; set; }
        public int UserId          { get; set; }
        public int CommGrade       { get; set; }
        public int SeverGrade      { get; set; }
        public string CommentContent  { get; set; }
        public string RevertContent   { get; set; }
        public string CommentPic      { get; set; }
        public DateTime CommentTime     { get; set; }
        public int days { get; set; }
    }
}

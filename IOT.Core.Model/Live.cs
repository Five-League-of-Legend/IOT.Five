using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 直播
    /// </summary>
    public class Live
    {
        public int LiveId        { get; set; }
        public string LiveTitle     { get; set; }
        public string Remark        { get; set; }
        public string LiveCover     { get; set; }
        public string GoodId        { get; set; }
        public int LiveModel     { get; set; }
        public int AnchorId      { get; set; }
        public DateTime BeginLiveDate { get; set; }
        public DateTime EndLiveDate   { get; set; }
        public int IsEnable { get; set; }
        public string AnchorName { get; set; }
    }
}

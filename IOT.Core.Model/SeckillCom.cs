using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 秒杀商品
    /// </summary>
    public  class SeckillCom
    {
        public int SeckillComId   { get; set; }
        public int ActivityId     { get; set; }//活动外键
        public int CommodityId    { get; set; }//商品外键
        public string  SeckillTitle   { get; set; }
        public string SeckillRemaek  { get; set; }
        public int SeckillModel   { get; set; }
        public int TackTime       { get; set; }
        public DateTime ActionDate     { get; set; }
        public int State          { get; set; }
        public float SeckilPrice    { get; set; }
        public int LimitNum { get; set; }
        public string ActivityName { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Diff { get { return BeginTime.ToString("HH:ss") + "-" + EndTime.ToString("HH:ss"); } }
        public string CommodityPic { get; set; }
        public float ShopPrice { get; set; }
        public DateTime times { get; set; }
        public string CommodityName { get; set; }

    }
}

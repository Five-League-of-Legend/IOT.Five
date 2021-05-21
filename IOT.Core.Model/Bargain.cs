using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class Bargain
    {
        public int BargainId { get; set; }
        public int CommodityId { get; set; }
        public int PeopleNum { get; set; }
        public int KNum { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Astrict { get; set; }
        public int ActionState { get; set; }
        public int PartNum { get; set; }
        public float MinPrice { get; set; }
        public int SurplusNum { get; set; }
        public int SurplusBargain { get; set; }
        public string BargainName { get; set; }
        public string BargainRemark { get; set; }
        public int Template { get; set; }
        public int LimitNum { get; set; }
        public float BargainSum { get; set; }
        public string CommodityPic { get; set; }
        public string CommodityName { get; set; }
        public string Remark { get; set; }
    }
}

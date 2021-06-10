using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 门店
    /// </summary>
   public   class Store
    {
        public int Mid { get; set; }
        public string MName { get; set; }
        public string Shopowner { get; set; }
        public int Goods { get; set; }
        public decimal Volume { get; set; }
        public int StoreType { get; set; }
        public int Extraction { get; set; }
        public int State { get; set; }
        public string StoreNo { get; set; }
        public string Pwd { get; set; }
        public string Phone { get; set; }
        public string Background { get; set; }
        public string Logo { get; set; }
        public int Approve { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 门店配置
    /// </summary>
    public class Store_Configuration
    {
        public int StoreId { get; set; }
        public string StorePic { get; set; }
        public string StoreName { get; set; }
        public int State { get; set; }
        public DateTime CreateTime { get; set; }
        public string CTime { get { return CreateTime.ToString("yyyy-MM-dd HH:MM:ss"); } }

    }
}

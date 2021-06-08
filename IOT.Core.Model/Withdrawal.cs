using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 提现表
    /// </summary>
    public class Withdrawal
    {
        public int Wid { get; set; }
        public decimal Wprice { get; set; }
        public int Wtype { get; set; }
        public string CollectionName { get; set; }
        public string WNumber { get; set; }
        public DateTime Wtime { get; set; }
        public string WTTime { get { return Wtime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int State { get; set; }
        public int Mid { get; set; }
        public string Mname { get; set; }
    }
}

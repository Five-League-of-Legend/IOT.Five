using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class Specification
    {
        public int SId { get; set; }
        public string SpecificationName { get; set; }
        public string CommSpec { get; set; }
        public string CommProp { get; set; }
        public int SpecificationValue { get; set; }
    }
}

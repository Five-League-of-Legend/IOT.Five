using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.SVIP;

namespace IOT.Core.Repository.SVIP
{
    public class SVIPRepository : ISVIPRepository
    {
        public int AddSvip(Model.SVIP a)
        {
            try
            {
                string sql = $"insert into Svip values (null,'{a.SName}', '{a.BackgroudColor}', '{a.Icon}', '{a.BCImg}', {a.Consume}, {a.Commission}, {a.Money},'{a.Rate}', '{a.Explains}')";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

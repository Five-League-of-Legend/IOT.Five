using IOT.Core.Common;
using IOT.Core.IRepository.MiniProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.MiniProgram
{
    public class MiniProgramRepository : IMiniProgramRepository
    {
        /// <summary>
        /// 小程序显示
        /// </summary>
        /// <returns></returns>
        public List<Model.MiniProgram> MiniPrograms()
        {
            string sql = $" select * from MiniProgram ";
            return DapperHelper.GetList<Model.MiniProgram>(sql);
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="miniProgram"></param>
        /// <returns></returns>
        public int UptMiniProgram(Model.MiniProgram miniProgram)
        {
            string sql = $" update MiniProgram set APPID='{miniProgram.APPID}'," +
                $"SECRET='{miniProgram.SECRET}',MerchantCode={miniProgram.MerchantCode}," +
                $"SecretKey='{miniProgram.SecretKey}',CertificateCERT='{miniProgram.CertificateCERT}'," +
                $"CertificateKEY='{miniProgram.CertificateKEY}',Payment='{miniProgram.Payment}'  where procedureid={miniProgram.procedureid} ";
            return DapperHelper.Execute(sql);
        }

    }
}

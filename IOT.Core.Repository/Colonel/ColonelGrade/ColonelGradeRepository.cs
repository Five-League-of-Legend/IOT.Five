using IOT.Core.Common;
using IOT.Core.IRepository.Colonel.ColonelGrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel.ColonelGrade
{
    public class ColonelGradeRepository : IColonelGradeRepository
    {
        /// <summary>
        /// 删除团长等级
        /// </summary>
        /// <param name="CGId">团长等级Id</param>
        /// <returns></returns>
        public int DelColonelGrade(int CGId)
        {
            try
            {
                string sql = $" delete from ColonelGrade where CGId = {CGId} ;";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 显示团长等级      根据团长等级ID反填
        /// </summary>
        /// <param name="CGId">团长等级ID</param>
        /// <returns></returns>
        public List<Model.ColonelGrade> ShowColonelGrade(int CGId)
        {
            string sql = $" select * from ColonelGrade ";

            try
            {
                if (CGId != -1)
                {
                    sql += $" where CGId={CGId} ";
                }

                return DapperHelper.GetList<Model.ColonelGrade>(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 编辑团长等级
        /// </summary>
        /// <param name="colonelGrade">团长等级</param>
        /// <returns></returns>
        public int UptColonelGrade(Model.ColonelGrade colonelGrade)
        {
            try
            {
                string sql = $" update ColonelGrade set CGradeName='{colonelGrade.CGradeName}',GradeExperience='{colonelGrade.GradeExperience}',FirstPY={colonelGrade.FirstPY},AwardRatio='{colonelGrade.AwardRatio}',GradeStatus={colonelGrade.GradeStatus} where CGId = {colonelGrade.CGId} ;";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

using IOT.Core.Common;
using IOT.Core.IRepository.Colonel.ColonelManagement;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel.ColonelManagement
{
    public class ColonelManagementRepository : IColonelManagementRepository
    {

        /// <summary>
        /// 添加核销员
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddUsers(Model.Users a)
        {
            try
            {
                string sql = $"  update Users set ColonelID = {a.ColonelID} where UserId = {a.UserId} ;";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 显示搜索团长
        /// </summary>
        /// <param name="CheckStatus">审核状态</param>
        /// <param name="nm">姓名</param>
        /// <returns></returns>  
        public List<Model.ViewColonelAndManager> ShowColonelList(int CheckStatus, string nm)
        {
            //string sql = "  select * from Colonel join ColonelManagement on Colonel.ColonelID in (ColonelManagement.ColonelID) where 1=1  ";

            string sql = @" select a.ColonelID,a.Estate,a.NickName,a.Sex,a.Phone,a.ColonelName,a.MemberNum,a.PColonelId,a.Region,a.Address,a.Coordinates,a.RegisterTime,a.Integral,a.Saleroom,a.DeliveryStatus,a.Cost,a.Alipay,a.BankSite,a.CardName,a.BankCard,a.HeadPortrait,a.CommIds, b.CMId,b.ColonelID,b.ColonelID,b.AapplyTime,b.CheckTime,b.CheckStatus,b.CheckName from Colonel a join ColonelManagement b on a.ColonelID in (b.ColonelID) where 1=1";

            try
            {
                if (CheckStatus != -1)
                {
                    sql += $" and b.CheckStatus = {CheckStatus} ";
                }


                List<Model.ViewColonelAndManager> list = DapperHelper.GetList<Model.ViewColonelAndManager>(sql);

                if (!string.IsNullOrEmpty(nm))
                {
                    list = list.Where(m => m.ColonelName.Contains(nm)).ToList();
                }

                return list;

            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// 显示核销员
        /// </summary>
        /// <param name="ColonelID">团长ID</param>
        /// <returns></returns>
        public List<Model.Users> ShowUsers(int ColonelID)
        {
            try
            {
                string sql = $" select * from Users where ColonelID = {ColonelID} ";
                return DapperHelper.GetList<Model.Users>(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 编辑团长
        /// </summary>
        /// <param name="a">编辑团长</param>
        /// <returns></returns>
        public int UptColonel(Model.Colonel a)
        {
            try
            {
                string sql = @$"  update Colonel set Nickname='{a.NickName}',Sex={a.Sex},Phone='{a.Phone}',ColonelName='{a.ColonelName}',MemberNum={a.MemberNum},PColonelId='{a.PColonelId}',
                        Region='{a.Region}',  Estate='{a.Estate}',Address='{a.Address}',Coordinates='{a.Coordinates}',RegisterTime='{a.RegisterTime}',Integral={a.Integral},Saleroom={a.Saleroom},
                        DeliveryStatus={a.DeliveryStatus},Cost={a.Cost},Alipay='{a.Alipay}',BankSite='{a.BankSite}',CardName='{a.CardName}',BankCard='{a.BankCard}',HeadPortrait='{a.HeadPortrait}',
                        CommIds='{a.CommIds}'
                         where ColonelID = {a.ColonelID} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 团长审核修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UptColonel_CheckStatus(Model.ColonelManagement a)
        {
            try
            {
                string sql = $" update ColonelManagement set CheckStatus={a.CheckStatus} where CMId = {a.CMId} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 绑定团长商品
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Upt_Commodity_Colonel(Model.Colonel a)
        {

            try
            {
                string sql = $" update Colonel set CommIds='{a.CommIds}' where ColonelID = {a.ColonelID} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

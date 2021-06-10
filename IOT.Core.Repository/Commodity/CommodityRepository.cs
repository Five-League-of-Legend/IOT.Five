using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository;
using IOT.Core.IRepository.CommodityRepository;

namespace IOT.Core.Repository.Commodity
{
    public class CommodityRepository : ICommodityRepository
    {
        public int Delete(string ids)
        {
            string sql = $"delete from Commodity where CommodityId in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Commodity Model)
        {
            try
            {
                string sql = $"insert into Commodity values(null,'{Model.CommodityName}','{Model.CommodityPic}','{Model.ShopPrice}',{Model.ShopNum},{Model.Repertory},{Model.Sort},0,now(),{Model.TId},'{Model.Remark}',{Model.TemplateId},'{Model.CommodityKey}','{Model.SendAddress}','{Model.Job}',{Model.Integral},{Model.SId},'{Model.Color}','{Model.Size}',0,0,{Model.CostPrice},{Model.ColonelID},{Model.Mid})";

                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
         
        }


        public int Uptstate(int id)
        {
            try
            {
                var list = DapperHelper.GetList<Model.Commodity>($"select * from Commodity ").ToList();
                IOT.Core.Model.Commodity commodity = list.FirstOrDefault(m => m.CommodityId == id);
                if (commodity.DeleteState == 0)
                {
                    commodity.DeleteState = 1;
                }
                else
                {
                    commodity.DeleteState = 0;
                }

                string sql = $"update Commodity set DeleteState={commodity.DeleteState} where CommodityId={commodity.CommodityId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public int Uptsstate(int id)
        {
            try
            {
                IOT.Core.Model.Commodity commodity = DapperHelper.GetList<Model.Commodity>($"select * from Commodity where CommodityId={id}").FirstOrDefault();
                if (commodity.IsSell == 0)
                {
                    commodity.IsSell = 1;
                }
                else
                {
                    commodity.IsSell = 0;
                }
                string sql = $"update Commodity set IsSell={commodity.IsSell} where CommodityId={commodity.CommodityId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public List<Model.Commodity> Query(int code, int tid, string keyname)
        {
            try
            {
                string sql = "";
                if (code == 1)
                {
                    sql = "select * from Commodity a JOIN CommType b on a.Tid=b.TId where a.State =1 and DeleteState=0";
                }
                 if (code == 2)
                {
                    sql = "select * from Commodity a JOIN CommType b on a.Tid=b.TId where DeleteState=0";
                }
                 if (code == 3)
                {
                    sql = "select * from Commodity a JOIN CommType b on a.Tid=b.TId where DeleteState=0 and IsSell=1";
                }
                 if (code == 4)
                {
                    sql = "select * from Commodity a JOIN CommType b on a.Tid=b.TId where DeleteState=1";
                }
                List<Model.Commodity> mm = DapperHelper.GetList<Model.Commodity>(sql);
                if (tid != 0)
                {
                    mm = mm.Where(x => x.TId.Equals(tid)).ToList();
                }
                if (!string.IsNullOrEmpty(keyname))
                {
                    mm = mm.Where(x => x.CommodityName.Contains(keyname)).ToList();
                }
                return mm;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public List<Model.Commodity> BindShowCom()
        {
            string sql = "select * from Commodity ";
            return DapperHelper.GetList<Model.Commodity>(sql);
        }
        public int Upt(Model.Commodity cc)
        {
            try
            {
            string sql = $"update Commodity set CommodityName='{cc.CommodityName}',CommodityPic='{cc.CommodityPic}',ShopPrice='{cc.ShopPrice}',ShopNum={cc.ShopNum},Repertory={cc.Repertory},Sort={cc.Sort},State={cc.State},OperationDate='{cc.OperationDate}' where CommodityId={cc.CommodityId}";
            return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

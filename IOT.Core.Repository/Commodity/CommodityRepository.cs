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
            throw new NotImplementedException();
        }

        public int Insert(Model.Commodity Model)
        {
            string sql = $"insert into Commodity values(null,'{Model.CommodityName}','{Model.CommodityPic}','{Model.ShopPrice}',{Model.ShopNum},{Model.Repertory},{Model.Sort},0,now(),{Model.TId},'{Model.Remark}',{Model.TemplateId},'{Model.CommodityKey}','{Model.SendAddress}','{Model.Job}',{Model.Integral},{Model.SId},'{Model.Color}','{Model.Size}',0,0,{Model.CostPrice},{Model.ColonelID},{Model.Mid})";

            return DapperHelper.Execute(sql);
        }

        public List<Model.Commodity> Query()
        {
            string sql = "select * from Commodity ";
            return DapperHelper.GetList<Model.Commodity>(sql);
        }
        public int Uptstate(int id)
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
        public int Uptsstate(int id)
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
    }
}

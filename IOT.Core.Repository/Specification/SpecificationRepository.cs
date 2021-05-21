using IOT.Core.Common;
using IOT.Core.IRepository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IOT.Core.Repository.Specification
{
    public class SpecificationRepository : ISpecificationRepository
    {

        public int Delete(string ids)
        {
            string sql = $"delete from Specification where SId={ids}";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Specification Model)
        {
            string sql = $"insert into Specification values(null,'{Model.SpecificationName}','{Model.CommSpec}','{Model.CommProp}',{Model.SpecificationValue})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Specification> Query(string commspec="")
        {
            string sql = $"select * from Specification where 1=1";
            if (!string.IsNullOrEmpty(commspec))
            {
                sql += $" and Commspec like '%{commspec}%'";
            }
            return DapperHelper.GetList<Model.Specification>(sql);


        }
        public List<Model.Specification> UptState(int id)
        {
            string sql = $"select * from Specification where SId ={id}";
            return DapperHelper.GetList<Model.Specification>(sql);
        }
        public int Uptss(Model.Specification c)
        {
            string sql = $"update CommType set SpecificationName='{c.SpecificationName}' where SId={c.SId} ";
            return DapperHelper.Execute(sql);
        }

        public int Deletes(string id)
        {

            string sql = $"delete from Specification where SId in ({id})";

            return DapperHelper.Execute(sql);

        }



        public List<Model.Specification> Query()
        {
            throw new NotImplementedException();
        }
    }
}

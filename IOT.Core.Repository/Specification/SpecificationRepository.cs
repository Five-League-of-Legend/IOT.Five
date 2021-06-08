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
            try
            {
                string sql = $"delete from Specification where SId={ids}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int Insert(Model.Specification Model)
        {
            try
            {
                string sql = $"insert into Specification values(null,'{Model.SpecificationName}','{Model.CommSpec}','{Model.CommProp}',{Model.SpecificationValue})";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Model.Specification> Query(string commspec="")
        {
            try
            {
                string sql = $"select * from Specification where 1=1";
                if (!string.IsNullOrEmpty(commspec))
                {
                    sql += $" and Commspec like '%{commspec}%'";
                }
                return DapperHelper.GetList<Model.Specification>(sql);
            }
            catch (Exception)
            {

                throw;
            }
          


        }
        public List<Model.Specification> UptState(int id)
        {
            try
            {
                string sql = $"select * from Specification where SId ={id}";
                return DapperHelper.GetList<Model.Specification>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public int Uptss(Model.Specification c)
        {
            try
            {
                string sql = $"update Specification set SpecificationName='{c.SpecificationName}',CommSpec='{c.CommSpec}',CommProp='{c.CommProp}',SpecificationValue={c.SpecificationValue} where SId = {c.SId} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int Deletes(string id)
        {
            try
            {
                string sql = $"delete from Specification where SId in ({id})";

                return DapperHelper.Execute(sql);

            }
            catch (Exception)
            {

                throw;
            }
          
        }



        public List<Model.Specification> Query()
        {
            throw new NotImplementedException();
        }
    }
}

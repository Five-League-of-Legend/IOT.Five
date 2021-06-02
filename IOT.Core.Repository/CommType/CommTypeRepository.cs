using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository;
using IOT.Core.IRepository.CommType;

namespace IOT.Core.Repository.CommType
{
    public class CommTypeRepository : ICommTypeRepository
    {
        public int Delete(string ids)
        {
            try
            {
                int sss = Convert.ToInt32(DapperHelper.Exescalar($"select count(*) from CommType where ParentId={ids}"));
                if (sss > 0)
                {
                    return 0;
                }
                else
                {
                    string sql = $"delete from CommType where TId in ({ids})";
                    return DapperHelper.Execute(sql);
                }
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }

        public int Insert(Model.CommType Model)
        {
            try
            {
                string sql = $"insert into CommType values (null,'{Model.TName}',{Model.Sort},'{Model.TIcon}',{Model.State},{Model.ParentId})";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Model.CommType> Bang(int ParentId)
        {
            try
            {
                string sql = $"select * from CommType where ParentId=0";

                return DapperHelper.GetList<Model.CommType>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public List<Model.CommType> Query(string ttname,int state)
        {
            try
            {
                string sql = $"select * from CommType";

                return DapperHelper.GetList<Model.CommType>(sql);
            }
            catch (Exception)
            {

                throw;
            }
         
        }
        //public List<Model.CommType> UptState(int id)
        //{
        //    string sql = $"select * from CommType where TId ={id}";
        //    return DapperHelper.GetList<Model.CommType>(sql);
        //}

        public int UptState(int id)
        {
            try
            {
                string sql = $"update CommType set State=ABS(State-1) where TId={id} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
         
        }
        public int Uptss(Model.CommType c)
        {
            try
            {
                string sql = $"update CommType set TName='{c.TName}',Sort={c.Sort},TIcon='{c.TIcon}',State={c.State},ParentId={c.ParentId} where TId={c.TId} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        
    }
}

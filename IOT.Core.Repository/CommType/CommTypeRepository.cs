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
            int sss = Convert.ToInt32(DapperHelper.Exescalar($"select count(*) from CommType where ParentId={ids}"));
            if (sss>0)
            {
               string sql = $"delete from CommType where TId in ({ids})"; 
                return DapperHelper.Execute(sql);
            }
            else
            {
                return 0;
            }
           
        }

        public int Insert(Model.CommType Model)
        {
            string sql = $"insert into CommType values (null,'{Model.TName}',{Model.Sort},'{Model.TIcon}',{Model.State},{Model.ParentId})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.CommType> Query(int tid=0)
        {
            string sql = $"select * from CommType";
            if (tid!=0)
            {
                sql += $"  where TId ={tid}";
            }
            return DapperHelper.GetList<Model.CommType>(sql);
        }
        public List<Model.CommType> UptState(int id)
        {
            string sql = $"select * from CommType where TId ={id}";
            return DapperHelper.GetList<Model.CommType>(sql);
        }
        public int Uptss(Model.CommType c)
        {
            string sql = $"update CommType set TName='{c.TName}',Sort={c.Sort} where TId={c.TId} ";
            return DapperHelper.Execute(sql);
        }

        public List<Model.CommType> Query()
        {
            throw new NotImplementedException();
        }

      
    }
}

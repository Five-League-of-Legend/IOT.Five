using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.StaffAuthority;
namespace IOT.Core.Repository.StaffAuthority
{
    public class StaffAuthorityRepository : IStaffAuthorityRepository
    {
        public string FanMenu(int rid)
        {
            try
            {
                //找到此rid对应所有的menuid 
                string sql = $"select MenuID from staffauthority where menuid IN (select menuid from menu where menuid  not in (select parentid from menu )) and rid={rid} ";
                var query = DapperHelper.GetList<IOT.Core.Model.Menu>(sql);
                StringBuilder sb = new StringBuilder();
                foreach (var s in query)
                {
                    sb.Append(s.MenuID).Append(',');
                }
                var arr = "[" + sb.ToString().TrimEnd(',') + "]";
                return arr;
            }
            catch (Exception)
            {

                throw;
            }
           


        }

        public int UptAut(int rId, string menuID)
        {
            try
            {
                int i = 0;
                //先删除此角色下边的所有权限
                string sql = $"delete from staffauthority where rid={rId}";
                DapperHelper.Execute(sql);
                string[] arr = menuID.Split(',');  //按逗号隔开放入数组
                foreach (var s in arr)
                {
                    string str = $"insert into staffauthority(rid,menuid) values ({rId},{s})";
                    i += DapperHelper.Execute(str);
                }
                return i;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}






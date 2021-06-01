using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Agent;

namespace IOT.Core.Repository.Agent
{
    //public class ActivityRepository : IActivityRepository
    public class AgentRepository : IAgentRepository
    {
        
        public int AddAgent(Model.Agent a)
        {        
            string sql = $"insert into Agent values (null,'{a.AgentName}','{a.BackgroudColor}','{a.Icon}','{a.BCImg}','{a.Fans}',{a.Consume},{a.Money},'{a.NFans}',{a.Two},{a.Three},{a.One},'{a.Explaina}',{a.AgentState})";
           return DapperHelper.Execute(sql);
        }

        public int DelAgent(string id)
        {
            string sql = $"delete from Agent where AgentId={id}";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Agent> ShowAgent()
        {
            string sql = "select * from Agent";
            return DapperHelper.GetList<Model.Agent>(sql);  
        }
       

        public int UptAgent(Model.Agent a)
        {
            
            string sql = $"update  Agent set AgentName='{a.AgentName}',BackgroudColor='{a.BackgroudColor}',Icon='{a.Icon}',BCImg='{a.BCImg}',Fans='{a.Fans}',Consume={a.Consume},Money={a.Money},NFans='{a.NFans}',Two={a.Two},Three={a.Three},One={a.One},Explaina='{a.Explaina}',AgentState={a.AgentState}";
           
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int cid)
        {
            string sql = "select * from Agent";
            
            List<Model.Agent> la = DapperHelper.GetList<Model.Agent>(sql);

            Model.Agent aa = la.FirstOrDefault(x => x.AgentId.Equals(cid));
            string sql1 = "";
            if (aa.AgentState == 0)
            {
                sql1 = $"UPDATE Agent SET AgentState=AgentState+1 where AgentId={cid}";
                
            }
            else
            {
                sql1 = $"UPDATE Agent SET AgentState=AgentState-1 where AgentId={cid}";
               
            }
            int i = DapperHelper.Execute(sql1);
            return i;
        }
       

    }
}

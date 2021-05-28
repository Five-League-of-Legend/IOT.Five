using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Colonel.Path
{
    public interface IPathRepository
    {
        /// <summary>
        /// 添加路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int AddPath(Model.Path a);

        /// <summary>
        /// 显示路线
        /// </summary>
        /// <param name="PathID">路线ID</param>
        /// <returns></returns>
        List<Model.Path> ShowPath(string nm);


        /// <summary>
        /// 修改路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int UptPath(Model.Path a);

        /// <summary>
        /// 删除路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int DelPath(int PathID);


    }
}

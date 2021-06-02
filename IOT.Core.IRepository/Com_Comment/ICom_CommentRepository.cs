using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Com_Comment
{
    public interface ICom_CommentRepository
    {
        int Upt(Model.Com_Comment cs);
        int Delete(string ids);

        int Insert(Model.Com_Comment Model);
        List<Model.Com_Comment> Query(string commentcontent = "", int commodityid = 0, int userid = 0);
    }
}

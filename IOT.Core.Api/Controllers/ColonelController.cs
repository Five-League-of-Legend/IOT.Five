using IOT.Core.IRepository.Colonel;
using IOT.Core.IRepository.Colonel.Brokerage;
using IOT.Core.IRepository.Colonel.ColonelGrade;
using IOT.Core.IRepository.Colonel.ColonelManagement;
using IOT.Core.IRepository.Colonel.GroupPurchase;
using IOT.Core.IRepository.Colonel.Path;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColonelController : ControllerBase
    {
        #region
        private IColonelRepository _colonelRepository;
        private IColonelManagementRepository _colonelManagementRepository;
        private IColonelGradeRepository _colonelGradeRepository;
        private IGroupPurchaseRepository _groupPurchaseRepository;
        private IPathRepository _pathRepository;
        private IBrokerageRepository _brokerageRepository;

        public ColonelController(
            IColonelRepository colonelRepository,
            IColonelManagementRepository colonelManagementRepository,
            IColonelGradeRepository colonelGradeRepository,
            IGroupPurchaseRepository groupPurchaseRepository,
            IPathRepository pathRepository,
            IBrokerageRepository brokerageRepository
            )
        {
            _colonelRepository = colonelRepository;
            _colonelManagementRepository = colonelManagementRepository;
            _colonelGradeRepository = colonelGradeRepository;
            _groupPurchaseRepository = groupPurchaseRepository;
            _pathRepository = pathRepository;
            _brokerageRepository = brokerageRepository;
        }

        #endregion

        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化

        //================================================================================================

        /// <summary>
        /// 佣金流水   两表联查
        /// </summary>
        /// <param name="time">时间范围</param>
        /// <param name="orderFormStatus">订单状态</param>
        /// <param name="colonel">所属团长</param>
        /// <param name="orderNumber">订单号</param>
        /// <param name="brokerageState">佣金状态</param>
        /// <returns></returns>  
        [HttpGet]
        [Route("/api/GetBrokerages")]
        public IActionResult GetBrokerages(int orderFormStatus, int brokerageState, string time = "", string orderNumber = "aaa", string colonel = "aaa")
        {
            List<Model.ViewColonelAndBrokerage> list = _brokerageRepository.GetBrokerages(time, orderFormStatus, colonel, orderNumber, brokerageState);

            if (time != "aaa" & time!="" )
            {
                list = list.Where(m => m.EndTime <= Convert.ToDateTime(time)).ToList();
            }

            logger.Debug($"查看佣金流水");

            return Ok(list);
        }


        /// <summary>
        /// 删除佣金流水
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DelBrokerage")]
        public int DelBrokerage(int id)
        {
            int i = _brokerageRepository.DelBrokerage(id);

            if (i>0)
            {
                logger.Debug($"删除佣金流水成功,id为{id}");
            }
            else
            {
                logger.Debug($"删除佣金流水失败,id为{id}");
            }

            return i;
        }


        /// <summary>
        /// 修改佣金流水
        /// </summary>
        /// <param name="brokerage"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptBrokerage")]
        public int UptBrokerage(Model.Brokerage brokerage)
        {
            int i = _brokerageRepository.UptBrokerage(brokerage);

            if (i > 0)
            {
                logger.Debug($"修改佣金流水成功,id为{brokerage.BId}");
            }
            else
            {
                logger.Debug($"修改佣金流水失败,id为{brokerage.BId}");
            }

            return i;
        }

        /// <summary>
        /// 添加佣金流水
        /// </summary>
        /// <param name="brokerage"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddBrokerage")]
        public int AddBrokerage(Model.Brokerage brokerage)
        {
            int i = _brokerageRepository.AddBrokerage(brokerage);

            if (i > 0)
            {
                logger.Debug($"添加佣金流水成功,id为{brokerage.BId}");
            }
            else
            {
                logger.Debug($"添加佣金流水失败,id为{brokerage.BId}");
            }

            return i;
        }



        //-------------------------------------------------------------------------------------------------
        //5.20

        /// <summary>
        /// 显示团长等级      根据团长等级ID反填
        /// </summary>
        /// <param name="CGId">团长等级ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowColonelGrade")]
        public IActionResult GetShowColonelGrade(int CGId = -1)
        {
            List<Model.ColonelGrade> colonelGrades = _colonelGradeRepository.ShowColonelGrade(CGId);

            logger.Debug($"显示团长等级");

            return Ok(colonelGrades);
        }

        /// <summary>
        /// 编辑团长等级
        /// </summary>
        /// <param name="colonelGrade">团长等级</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptColonelGrade")]
        public int UptColonelGrade(Model.ColonelGrade colonelGrade)
        {
            int i = _colonelGradeRepository.UptColonelGrade(colonelGrade);

            if (i > 0)
            {
                logger.Debug($"编辑团长等级成功,id为{colonelGrade.CGId}");
            }
            else
            {
                logger.Debug($"编辑团长等级失败,id为{colonelGrade.CGId}");
            }

            return i;
        }

        /// <summary>
        /// 删除团长等级
        /// </summary>
        /// <param name="CGId">团长等级Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DelColonelGrade")]
        public int DelColonelGrade(int CGId)
        {
            int i = _colonelGradeRepository.DelColonelGrade(CGId);

            if (i > 0)
            {
                logger.Debug($"删除团长等级成功,id为{CGId}");
            }
            else
            {
                logger.Debug($"删除团长等级失败,id为{CGId}");
            }

            return i;
        }

        /// <summary>
        /// 添加团购配置
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddGroupPurchase")]
        public int AddGroupPurchase([FromForm] Model.GroupPurchase gp)
        {
            int i = _groupPurchaseRepository.AddGroupPurchase(gp);

            if (i > 0)
            {
                logger.Debug($"添加团购配置成功,公告为{gp.Notice}");
            }
            else
            {
                logger.Debug($"添加团购配置失败,公告为{gp.Notice}");
            }

            return i;
        }

        // 路线             ------

        /// <summary>
        /// 显示路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowPath")]
        public IActionResult GetShowPath(string nm = "")
        {
            List<Model.Path> paths = _pathRepository.ShowPath(nm);

            logger.Debug($"显示团长路线");

            return Ok(paths);
        }

        /// <summary>
        /// 添加路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddPath")]
        public int AddPath([FromForm] Model.Path path)
        {
            int i = _pathRepository.AddPath(path);

            if (i > 0)
            {
                logger.Debug($"添加路线成功,路线名称为{path.PathName}");
            }
            else
            {
                logger.Debug($"添加路线失败,路线名称为{path.PathName}");
            }

            return i;
        }

        /// <summary>
        /// 删除路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/DelPath")]
        public int DelPath(int PathID)
        {
            int i = _pathRepository.DelPath(PathID);


            if (i > 0)
            {
                logger.Debug($"删除路线成功,路线id为{PathID}");
            }
            else
            {
                logger.Debug($"删除路线失败,路线id为{PathID}");
            }

            return i;
        }

        /// <summary>
        /// 修改路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptPath")]
        public int UptPath([FromForm] Model.Path path)
        {
            int i = _pathRepository.UptPath(path);

            if (i > 0)
            {
                logger.Debug($"修改路线成功,路线id为{path.RathID}");
            }
            else
            {
                logger.Debug($"修改路线失败,路线id为{path.RathID}");
            }

            return i;
        }

        //--------------------------------------------------------------------------------------------------
        //5.19
        #region

        /// <summary>
        /// 团长集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowColonel")]
        public IActionResult GetShowColonel(int cid)
        {
            List<Model.Colonel> colonels = _colonelRepository.ShowColonel(cid);

            logger.Debug($"显示团长");

            return Ok(colonels);
        }

        /// <summary>
        ///  团长审核管理显示搜索
        /// </summary>
        /// <param name="CheckStatus">审核状态 0 审核中 2 审核不通过 1 审核通过 -1 全部</param> 
        /// <param name="nm">关键字 团长姓名</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowColonelList")]
        public IActionResult GetShowColonelList(int CheckStatus = -1, string nm = "")
        {
            List<Model.ViewColonelAndManager> colonels = _colonelManagementRepository.ShowColonelList(CheckStatus, nm);

            logger.Debug($"显示团长审核信息");

            return Ok(colonels);
        }


        /// <summary>
        /// 团长审核修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/UptColonel_CheckStatus")]
        public int UptColonel_CheckStatus(int cmid, int statu)
        {
            Model.ColonelManagement colonelManagement = new Model.ColonelManagement() { CMId = cmid, CheckStatus = statu };

            int i = _colonelManagementRepository.UptColonel_CheckStatus(colonelManagement);

            if (i > 0)
            {
                logger.Debug($"修改团长审核状态成功,id为{cmid}");
            }
            else
            {
                logger.Debug($"修改团长审核状态失败,id为{cmid}");
            }

            return i;
        }

        /// <summary>
        /// 编辑团长
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptColonel")]
        public int UptColonel([FromForm] Model.Colonel colonel)
        {
            int i = _colonelManagementRepository.UptColonel(colonel);

            if (i > 0)
            {
                logger.Debug($"修改团长成功,id为{colonel.ColonelID}");
            }
            else
            {
                logger.Debug($"修改团长失败,id为{colonel.ColonelID}");
            }

            return i;
        }

        /// <summary>
        /// 编辑团长商品
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Upt_Commodity_Colonel")]
        public int Upt_Commodity_Colonel(Model.Colonel colonel)
        {
            int i = _colonelManagementRepository.Upt_Commodity_Colonel(colonel);


            if (i > 0)
            {
                logger.Debug($"修改团长商品成功,id为{colonel.ColonelID}");
            }
            else
            {
                logger.Debug($"修改团长商品失败,id为{colonel.ColonelID}");
            }

            return i;
        }

        /// <summary>
        /// 添加核销员
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddUsers")]
        public int AddUsers(int colonelid, string userids)
        {
            userids = userids.TrimEnd(',');
            string[] arr = userids.Split(',');

            Model.Users a = new Model.Users();
            a.ColonelID = colonelid;

            int i = 0;

            foreach (var item in arr)
            {
                a.UserId = Convert.ToInt32(item);
                i += _colonelManagementRepository.AddUsers(a);

            }


            if (i > 0)
            {
                logger.Debug($"添加核销员成功,id为{colonelid},添加的用户id为{userids}");
            }
            else
            {
                logger.Debug($"添加核销员失败,id为{colonelid},添加的用户id为{userids}");
            }

            return i;
        }

        /// <summary>
        /// 显示核销员
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowUsers")]
        public IActionResult GetShowUsers(int ColonelID)
        {

            List<Model.Users> users = _colonelManagementRepository.ShowUsers(ColonelID);

            logger.Debug($"显示团长下核销员,团长id为{ColonelID}");


            return Ok(users);
        }

        #endregion
    }
}

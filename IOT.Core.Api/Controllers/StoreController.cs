using IOT.Core.IRepository.Store;
using Microsoft.AspNetCore.Http;
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
    public class StoreController : ControllerBase
    {

        //实例化log
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        //显示商品
        [Route("/api/GetCommodity")]
        [HttpGet]
        public IActionResult GetCommodity(string ids)
        {
            var list = _storeRepository.GetCommodities();
            if (!string.IsNullOrEmpty(ids))
            {
                list = list.Where(x => x.CommodityId.ToString().Equals(ids) || x.CommodityName.Contains(ids)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }


        //显示门店
        [Route("/api/GetStores")]
        [HttpGet]
        public IActionResult GetStores()
        {
            var list = _storeRepository.GetStores();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }

        [Route("/api/ShowStores")]
        [HttpGet]
        public IActionResult ShowStores(string address = "", string key = "")
        {
            var list = _storeRepository.GetStores(address, key);
            return Ok(list);
        }
        [Route("/api/GetStoresFan")]
        [HttpGet]
        public IActionResult GetStoresFan(int id)
        {
            var list = _storeRepository.GetStoresFan(id);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }
        //删除商品
        [HttpDelete]
        [Route("/api/DelCom")]

        public int DelCom(int ids)
        {
            logger.Debug($"用户删除了商品表信息,删除的商品的ID为:{ids}");
            int i = _storeRepository.DelCom(ids);
            return i;
        }
        //删除门店
        [HttpDelete]
        [Route("/api/DelStore")]

        public int DelStore(int ids)
        {
            logger.Debug($"用户删除了门店表信息,删除的门店的ID为:{ids}");
            int i = _storeRepository.DelStore(ids);
            return i;
        }


        //添加门店
        [HttpPost]
        [Route("/api/InsertStore")]

        public int InsertStore([FromForm] Model.Store Model)
        {
            logger.Debug($"用户添加了门店表信息,添加的门店的名称为:{Model.MName}");
            int i = _storeRepository.InsertStore(Model);
            return i;
        }

        //修改门店
        [HttpPost]
        [Route("/api/UptStore")]
        public int UptStore([FromForm] Model.Store Model)
        {
            logger.Debug($"用户修改了门店表信息,修改的门店的名称为:{Model.MName}");
            int i = _storeRepository.UptStore(Model);
            return i;
        }

        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptCom")]
        public int UptCom(int cid)
        {
            logger.Debug($"用户修改了商品表状态,修改的商品的ID为:{cid}");
            int i = _storeRepository.UptCom(cid);
            return i;
        }

        [HttpPost]
        [Route("/api/UptStoreState")]

        public int UptStoreState(int id)
        {
            logger.Debug($"用户修改了门店表状态,修改的门店的ID为:{id}");
            int i = _storeRepository.UptStoreState(id);
            return i;
        }

    }
}

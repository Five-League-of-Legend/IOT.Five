﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Users;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        //显示
        [Route("/api/UsersShow")]
        [HttpGet]
        public IActionResult UsersShow(string keyname = "")
        {
            var ls = _usersRepository.ShowUsers();
            if (!string.IsNullOrEmpty(keyname))
            {
                ls = ls.Where(x => x.UserName.Contains(keyname)).ToList();
            }

           //return Ok(new { msg = "", code = 0, data = ls });
           //var ls = _usersRepository.ShowUsers();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //显示
        [Route("/api/ShowUsersWhereColonelID")]
        [HttpGet]
        public IActionResult ShowUsersWhereColonelID(int cid)
        {
            var ls = _usersRepository.ShowUsersWhereColonelID(cid);
            return Ok(ls);
        }

        
        //删除
        [Route("/api/UsersDel")]
        [HttpGet]
        public int UsersDel(string id)
        {
            return _usersRepository.DelUsers(id);
        }

        


        //修改
        [HttpPost]
        [Route("/api/UsersUpt")]
        public int UsersUpt([FromForm]IOT.Core.Model.Users a)
        {
            a.Phone = "14712345678";
            a.Address = "河北廊坊";
            a.State = 1;
            a.ColonelID = 1;
            a.RoleId = 1;
            return _usersRepository.UptUsers(a);
        }
        //修改状态
        [HttpPost]
        [Route("/api/UsersUptZt")]
        public int UsersUptZt(int cid)
        {

            return _usersRepository.UptZt(cid);
        }



        [HttpPost]
        [Route("/api/UsersAdd")]
        public int UsersAdd([FromForm]IOT.Core.Model.Users a)
        {
            // loginName userName  loginPwd nickName  显示添加信息
            // int UserId    { get    
            // string  UserName  {   默认后台
            // string LoginName { 
            // string LoginPwd  { 
            // string Phone     { 
            // string Address   { 
            // int State     { get
            // string NickName  { 
            // int ColonelID { get
            // int RoleId { get; s
            // string RoleName { g
            a.Phone = "14712345678";
            a.Address = "河北廊坊";
            a.State = 1;
            a.ColonelID = 1;
            a.RoleId = 1;
            int i = _usersRepository.AddUsers(a);
            return i;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayPI.Infrastructure.Auth.Jwt;
using RayPI.Infrastructure.Config;
using RayPI.Infrastructure.Security.Models;
using RayPI.Infrastructure.Security.Services;

namespace RayPI.OpenApi.Controllers
{
    /// <summary>
    /// 账号接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly AllConfigModel _allConfigModel;

        public AccountController(IJwtService jwtService, AllConfigModel allConfigModel)
        {
            _jwtService = jwtService;
            _allConfigModel = allConfigModel;
        }
        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public async Task<JsonResult> Login(string userName = "stuAdmin", string pwd = "123456", string roleName = "学生管理员")
        {
            // 用户名是否正确
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(roleName))
            {
                return new JsonResult(new
                {
                    Code = 0,
                    Message = "账号不存在",
                });
            }
            //密码是否正确
            if (!((userName == "stuAdmin" || userName == "bb" || userName == "cc") && pwd == "123456"))
            {
                return new JsonResult(new
                {
                    Code = 0,
                    Message = "密码错误",
                });
            }

            // 设置用户标识
            Claim[] userClaims = _jwtService.BuildClaims(userName, roleName);

            string tokenStr = _jwtService.BuildToken(userClaims);

            return new JsonResult(tokenStr);
        }
    }
}
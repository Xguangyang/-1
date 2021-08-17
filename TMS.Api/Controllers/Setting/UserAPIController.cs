using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MD5;
using TMS.Model.Entity;
using TMS.Model.Entity.Setting;
using TMS.Model.ViewModel;
using TMS.Service.Setting.Menu;
using TMS.Service.User;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 用户API
    /// </summary>
    [Route("UserAPI")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        //用户服务
        public readonly IUserService _userService;

        //构造函数进行注入
        public UserAPIController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        [Route("GetLogin")]
        [HttpGet]
        public async Task<IActionResult> GetLoginAsync(string userName, string userPwd)
        {
            try
            {
                //MD5加密
                userPwd = MD5Helper.Encrypt(userPwd);
                //执行登录
                UserModel userLogin = await _userService.GetLoginAsync(userName, userPwd);
                //判断是登录成功
                if (userLogin != null) {
                    UserRoleMenuViewModel.UserId = userLogin.UserID;//获取当前登录的用户Id
                    return Ok(new { code = true, meta = 200, msg = "登录成功" });
                }
                else
                    return Ok(new { code = false, meta = 500, msg = "登录失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "登录失败" });
            }
        }

       
    }
}

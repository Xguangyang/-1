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
using TMS.Common.Jwt;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 系统管理-用户API
    /// </summary>
    [Route("UserAPI")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        //用户服务
        public readonly IUserService _userService;

        private readonly ITokenHelper _tokenHelper;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="tokenHelper"></param>
        public UserAPIController(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
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
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                    {
                        { "LoginName", userName },
                    };
                    //（2） 后端：帮助类来生成JWT字符串，JWT字符串返回给浏览器
                    TnToken TnToken = _tokenHelper.CreateToken(keyValuePairs);
                    return Ok(new { code = true, meta = 200, msg = "登录成功",token= TnToken });
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

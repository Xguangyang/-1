using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;

namespace TMS.Service.User
{
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户</param>
        /// <param name="userPwd">密码</param>
        Task<UserModel> GetLoginAsync(string userName, string userPwd);
    }
}

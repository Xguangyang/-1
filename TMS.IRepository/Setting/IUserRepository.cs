using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;

namespace TMS.IRepository.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        Task<UserModel> GetLoginAsync(string userName, string userPwd);
    }
}

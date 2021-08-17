using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.User;
using TMS.Model.Entity;

namespace TMS.Service.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户</param>
        /// <param name="userPwd">密码</param>
        public async Task<UserModel> GetLoginAsync(string userName, string userPwd)
        {
            return await userRepository.GetLoginAsync(userName, userPwd);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.User;
using TMS.Model.Entity;

namespace TMS.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperClientHelper _SqlDB; //数据库连接

        public UserRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public async Task< UserModel> GetLoginAsync(string userName, string userPwd)
        {
            string sql = $"select * from UserModel where UserName=@userName and UserPwd=@userPwd";
            UserModel userLogin= await _SqlDB.QueryFirstAsync<UserModel>(sql, new { @userName = userName, @userPwd = userPwd });
            return userLogin;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.Setting;
using TMS.Model.Entity.Setting;
using TMS.Model.ViewModel;

namespace TMS.Repository.Setting
{
    public class MenuRepository: IMenuRepository
    {
        private readonly DapperClientHelper _SqlDB;//数据库连接

        public MenuRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 根据用户ID显示菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<MenuModel>> GetMenusAsync( )
        {
            string sql = "select e.MenuID,e.MenuName,e.MenuParentID,e.MenuLink,e.MenuIcon,e.MenuStatus from UserRoleModel a join UserModel b on a.UserId=b.UserId join RoleModel c on c.RoleId = a.RoleId join RoleMenuModel d on c.RoleId = d.RoleId join MenuModel e on e.MenuId = d.MenuId where b.UserId = @userId ";
            List<MenuModel> data = await _SqlDB.QueryAsync<MenuModel>(sql, new { @userId = UserRoleMenuViewModel.UserId });
            return data;
        }


    }
}

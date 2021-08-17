using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Setting;
using TMS.Model.Entity.Setting;

namespace TMS.Service.Setting.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menu;

        public MenuService(IMenuRepository menu)
        {
            _menu = menu;
        }

        /// <summary>
        /// 根据用户ID显示菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenuModel>> GetMenusAsync()
        {
            return await _menu.GetMenusAsync();
        }
    }
}

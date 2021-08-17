using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Setting;

namespace TMS.IRepository.Setting
{
    public interface IMenuRepository
    {
        /// <summary>
        /// 根据用户ID显示菜单
        /// </summary>
        /// <returns></returns>
        Task<List<MenuModel>> GetMenusAsync( );
    }
}

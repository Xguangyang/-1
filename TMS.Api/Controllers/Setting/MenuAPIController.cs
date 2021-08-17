using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity.Setting;
using TMS.Service.Setting.Menu;

namespace TMS.Api.Controllers.Setting
{
    /// <summary>
    /// 菜单API
    /// </summary>
    [Route("MenuAPI")]
    [ApiController]
    public class MenuAPIController : ControllerBase
    {
        public readonly IMenuService _menuService;

        public MenuAPIController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        /// <summary>
        /// 根据用户Id显示菜单
        /// </summary>
        /// <returns></returns>
        [Route("GetMenus")]
        [HttpGet]
        public async Task<IActionResult> GetMenusAsync()
        {
            List<MenuModel> data = await _menuService.GetMenusAsync();
            //判断
            if (data != null)
                return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
            else
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
        }

    }
}

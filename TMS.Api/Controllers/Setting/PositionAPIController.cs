using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.Setting;

namespace TMS.Api.Controllers.Setting
{
    /// <summary>
    /// 系统管理-职位管理
    /// </summary>
    [Route("PositionAPI")]
    [ApiController]
    [ApiWrapResult]
    //[Authorize]
    public class PositionAPIController : ControllerBase
    {
        private readonly IPositionService _position;

        public PositionAPIController(IPositionService position)
        {
            _position = position;
        }

        /// <summary>
        /// 显示职位信息
        /// </summary>
        /// <param name="positionName">职位名称查询</param>
        /// <returns></returns>
        [HttpGet,Route("GetPosition")]
        public async Task<IActionResult> GetPosition(string positionName)
        {
            return Ok(await _position.GetPosition(positionName));
        }


    }
}

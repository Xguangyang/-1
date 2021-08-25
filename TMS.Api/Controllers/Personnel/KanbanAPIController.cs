using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Model.ViewModel;
using TMS.Service.Personnel.Kanban;

namespace TMS.Api.Controllers.Personnel
{
    /// <summary>
    /// 人事管理-看板API
    /// </summary>
    [Route("KanbanAPI")]
    [ApiController]
    [ApiWrapResult]
    //[Authorize]
    public class KanbanAPIController : ControllerBase
    {
        private readonly IKanbanService _kanban;

        public KanbanAPIController(IKanbanService kanban)
        {
            _kanban = kanban;
        }


        /// <summary>
        /// 离职人数看板
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetLeaveKanban")]
        public async Task<IActionResult> GetLeaveKanban()
        {
            return Ok(await _kanban.GetLeaveKanban());
        }

    }
}

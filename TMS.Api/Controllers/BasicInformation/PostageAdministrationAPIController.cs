using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Model.Entity.BasicInformation;
using TMS.Service.BasicInformation.ThePostageManagement;

namespace TMS.Api.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息-油费API
    /// </summary>
    [Route("PostageAdministrationAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    [Authorize]
    public class PostageAdministrationAPIController : ControllerBase
    {
        private readonly IPostageAdministrationService _postage;

        public PostageAdministrationAPIController(IPostageAdministrationService Postage)
        {
            _postage = Postage;
        }

        /// <summary>
        /// 显示油费信息
        /// </summary>
        /// <param name="CarNum">车牌号</param>
        /// <param name="operatorName">经办人</param>
        /// <returns></returns>
        [Route("GetPostages")]
        [HttpGet]
        public async Task<IActionResult> GetPostages(string CarNum, string OperatorName)
        {
            return Ok(await _postage.GetPostages(CarNum, OperatorName));
        }


        /// <summary>
        /// 添加油费信息
        /// </summary>
        /// <param name="Model">信息</param>
        /// <returns></returns>
        [Route("AddPostage")]
        [HttpPost]
        public async Task<IActionResult> AddPostage(PostageAdministration Model)
        {
            return Ok(await _postage.AddPostage(Model));
        }


        /// <summary>
        /// 删除油费信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        [Route("DelPostage")]
        [HttpPost]
        public async Task<IActionResult> DelPostage(string Id)
        {
            return Ok(await _postage.DelPostage(Id));
        }

        /// <summary>
        /// 反填油费信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        [Route("EditPostage")]
        [HttpGet]
        public async Task<IActionResult> EditPostage(int Id)
        {
            return Ok(await _postage.EditPostage(Id));
        }

        /// <summary>
        /// 修改油费信息
        /// </summary>
        /// <param name="Model">信息</param>
        /// <returns></returns>
        [Route("UpdPostage")]
        [HttpPost]
        public async Task<IActionResult> UpdPostage(PostageAdministration Model)
        {
            return Ok(await _postage.UpdPostage(Model));
        }

    }
}

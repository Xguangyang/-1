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

        public PostageAdministrationAPIController(IPostageAdministrationService postage)
        {
            _postage = postage;
        }

        /// <summary>
        /// 显示油费信息
        /// </summary>
        /// <param name="carNum">车牌号</param>
        /// <param name="operatorName">经办人</param>
        /// <returns></returns>
        [Route("GetPostages")]
        [HttpGet]
        public async Task<IActionResult> GetPostages(string carNum, string operatorName)
        {
            return Ok(await _postage.GetPostages(carNum, operatorName));
        }


        /// <summary>
        /// 添加油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("AddOutsourcingUnit")]
        [HttpPost]
        public async Task<IActionResult> AddPostage(PostageAdministration model)
        {
            return Ok(await _postage.AddPostage(model));
        }


        /// <summary>
        /// 删除油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("DelOutsourcingUnit")]
        [HttpPost]
        public async Task<IActionResult> DelPostage(string id)
        {
            return Ok(await _postage.DelPostage(id));
        }

        /// <summary>
        /// 反填油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("EditOutsourcingUnit")]
        [HttpGet]
        public async Task<IActionResult> EditPostage(int id)
        {
            return Ok(await _postage.EditPostage(id));
        }

        /// <summary>
        /// 修改油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("UpdOutsourcingUnit")]
        [HttpPost]
        public async Task<IActionResult> UpdPostage(PostageAdministration model)
        {
            return Ok(await _postage.UpdPostage(model));
        }

    }
}

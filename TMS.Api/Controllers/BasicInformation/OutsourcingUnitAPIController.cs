using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Model.Entity.BasicInformation;
using TMS.Service.BasicInformation.ManagementOfOutsourcingUnits;

namespace TMS.Api.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息-外协单位管理API
    /// </summary>
    [Route("OutsourcingUnitAPI")]
    [ApiController]
    [ApiWrapResult]
    [Authorize]
    public class OutsourcingUnitAPIController : ControllerBase
    {
        private readonly IOutsourcingUnitService _outsourcingUnit;

        public OutsourcingUnitAPIController(IOutsourcingUnitService outsourcingUnit)
        {
            _outsourcingUnit = outsourcingUnit;
        }


        /// <summary>
        /// 外协单位显示
        /// </summary>
        /// <param name="name">外协单位名称查询</param>
        /// <param name="phone">外协单位手机号查询</param>
        /// <returns></returns>
        [Route("GetOutsourcingUnits")]
        [HttpGet]
        public async Task<IActionResult> GetOutsourcingUnits(string Name, string Phone)
        {
            return Ok(await _outsourcingUnit.GetOutsourcingUnits(Name, Phone));
        }

        /// <summary>
        /// 添加外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("AddOutsourcingUnit")]
        [HttpPost]
        public async Task<IActionResult> AddOutsourcingUnit(OutsourcingUnit Model)
        {
            return Ok(await _outsourcingUnit.AddOutsourcingUnit(Model));
        }

        /// <summary>
        /// 删除外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("DelOutsourcingUnit")]
        [HttpPost]
        public async Task<IActionResult> DelOutsourcingUnit(string Id)
        {
            return Ok(await _outsourcingUnit.DelOutsourcingUnit(Id));
        }

        /// <summary>
        /// 反填外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("EditOutsourcingUnit")]
        [HttpGet]
        public async Task<IActionResult> EditOutsourcingUnit(int Id)
        {
            return Ok(await _outsourcingUnit.EditOutsourcingUnit(Id));
        }

        /// <summary>
        /// 修改外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("UpdOutsourcingUnit")]
        [HttpPost]
        public async Task<IActionResult> UpdOutsourcingUnit(OutsourcingUnit Model)
        {
            return Ok(await _outsourcingUnit.UpdOutsourcingUnit(Model));
        }


    }
}

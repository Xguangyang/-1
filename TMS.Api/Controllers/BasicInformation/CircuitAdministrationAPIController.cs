using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Model.Entity.BasicInformation;
using TMS.Service.BasicInformation.LinkManagement;

namespace TMS.Api.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息—线路API
    /// </summary>
    [Route("CircuitAdministrationAPI")]
    [ApiController]
    [ApiWrapResult]
    [Authorize]
    public class CircuitAdministrationAPIController : ControllerBase
    {
        private readonly ICircuitAdministrationService _circuit;

        public CircuitAdministrationAPIController(ICircuitAdministrationService circuit)
        {
            _circuit = circuit;
        }

        /// <summary>
        /// 显示线路信息
        /// </summary>
        /// <param name="circuitName">线路名称</param>
        /// <param name="startAddress">起点</param>
        /// <param name="endAddress">终点</param>
        /// <param name="whether">是否是外协</param>
        /// <param name="phone">货主手机号</param>
        /// <param name="units">货主单位</param>
        /// <returns></returns>
        [Route("GetCircuits")]
        [HttpGet]
        public async Task<IActionResult> GetCircuits(string circuitName, string startAddress, string endAddress, string whether, string phone, string units)
        {
            return Ok(await _circuit.GetCircuits(circuitName, startAddress, endAddress, whether, phone, units));
        }


        /// <summary>
        /// 添加线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("AddCircuit")]
        [HttpPost]
        public async Task<IActionResult> AddCircuit(CircuitAdministration model)
        {
            return Ok(await _circuit.AddCircuit(model));
        }


        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("DelCircuit")]
        [HttpPost]
        public async Task<IActionResult> DelCircuit(string id)
        {
            return Ok(await _circuit.DelCircuit(id));
        }


        /// <summary>
        /// 反填线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("EditCircuit")]
        [HttpGet]
        public async Task<IActionResult> EditCircuit(int id)
        {
            return Ok(await _circuit.EditCircuit(id));
        }

        /// <summary>
        /// 修改线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("UpdCircuit")]
        [HttpPost]
        public async Task<IActionResult> UpdCircuit(CircuitAdministration model)
        {
            return Ok(await _circuit.UpdCircuit(model));
        }

        /// <summary>
        /// 小修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [HttpPost,Route("SmallUpd")]
        public async Task<IActionResult> SmallUpd(int id, int status)
        {
            return Ok(await _circuit.SmallUpd(id, status));
        }
    }
}

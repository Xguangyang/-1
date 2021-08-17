using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.ViewModel;
using TMS.Service.Setting.Department;

namespace TMS.Api.Controllers.Setting
{
    /// <summary>
    /// 系统管理-部门API
    /// </summary>
    [Route("DepartmentAPI")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        private readonly IDepartmentService _department;

        public DepartmentAPIController(IDepartmentService department)
        {
            _department = department;
        }

        /// <summary>
        /// 部门信息显示
        /// </summary>
        /// <param name="depName">部门名称查询</param>
        /// <returns></returns>
        [Route("GetDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsAsync(string depName)
        {
            List<DepartmentViewModel> data =await _department.GetDepartmentsAsync(depName);
            //判断
            if (data != null)
                return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
            else
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
        }
    }
}

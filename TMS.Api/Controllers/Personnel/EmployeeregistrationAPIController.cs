using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Service.Personnel;
using Microsoft.AspNetCore.Hosting;
using TMS.Model.ViewModel;
using TMS.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using TMS.Common.MyFilters;

namespace TMS.API.Controllers.Personnel.Employeeregistration
{
    /// <summary>
    /// 人事管理-员工登记API
    /// </summary>
    [Route("EmployeeregistrationAPI")]
    [ApiController]
    [ApiWrapResult]
    //[Authorize]
    public class EmployeeregistrationAPIController : Controller
    {
        /// <summary>
        /// 员工登记服务
        /// </summary>
        public readonly IEmployeeregistrationService _employeeregistration;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="employeeregistration"></param>
        /// <param name="hostingEnvironment"></param>
        [Obsolete]
        public EmployeeregistrationAPIController(IEmployeeregistrationService employeeregistration, IHostingEnvironment hostingEnvironment)
        {
            _employeeregistration = employeeregistration;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 人事模块—员工登记—显示API
        /// </summary>
        /// <returns></returns>
        [Route(nameof(GetEmployeeRegistrations))]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType)
        {
            return Ok( await _employeeregistration.GetEmployeeRegistrations(EmpName, EmpDeparName, PosterName, EmpPhone, EmpType));
        }

        /// <summary>
        /// 人事模块—员工登记—添加API
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [Route(nameof(AddEmployeeRegistrations))]
        [HttpPost]
        public async Task<IActionResult> AddEmployeeRegistrations(UserModel userModel)
        {
            return Ok( await _employeeregistration.AddEmployeeRegistrations(userModel));
        }
    }
}

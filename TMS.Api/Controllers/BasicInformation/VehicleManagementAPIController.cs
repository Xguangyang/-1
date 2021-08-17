using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.UpFiles;
using TMS.Model.Entity;
using TMS.Service.BasicInformation;

namespace TMS.Api.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息-车辆管理API
    /// </summary>
    [Route("VehicleManagementAPI")]
    [ApiController]
    public class VehicleManagementAPIController : ControllerBase
    {
        //用户服务
        public readonly IVehicleManagementService _carRegistration;

        private readonly IHostingEnvironment _hostingEnvironment;

        //构造函数进行注入
        public VehicleManagementAPIController(IVehicleManagementService carRegistration, IHostingEnvironment hostingEnvironment)
        {
            _carRegistration = carRegistration;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <param name="factoryPlate">厂牌型号</param>
        /// <param name="carNumber">车牌号</param>
        /// <param name="carName">司机名称</param>
        /// <param name="companies">所属公司</param>
        /// <returns></returns>
        [Route("GetCarRegistration")]
        [HttpGet]
        public async Task<IActionResult> GetCarRegistrationsAsync(string factoryPlate = "", string carNumber = "", string carName = "", string companies = "")
        {
            try
            {
                //数据集
                List<RegistrationModel> data = await _carRegistration.GetCarRegistrationsAsync(factoryPlate, carNumber, carName, companies);
                //判断
                if (data != null)
                    return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = 0, data = "" });
            }
        }


        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        [Route("AddCar")]
        [HttpPost]
        public async Task<IActionResult> AddCarAsync(RegistrationModel model)
        {
            try
            {
                bool data = await _carRegistration.AddCarAsync(model);
                if (data == true)
                    return Ok(new { code = data, meta = 200, msg = "添加成功" });
                else
                    return Ok(new { code = data, meta = 500, msg = "添加失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "添加失败" });
            }
        }

        /// <summary>
        /// 上传图片车辆照片
        /// </summary>
        /// <returns></returns>
        [Route("UpLoadRegistrationImg")]
        [HttpPost]
        public string UpLoadRegistrationImg()
        {
            IFormFile formFile = Request.Form.Files[0];
            UploadFilesHelper upload = new UploadFilesHelper(_hostingEnvironment, "/Image/");
            string file = upload.Main(formFile);
            return file;
        }

        /// <summary>
        /// 上传图片保险卡照片
        /// </summary>
        /// <returns></returns>
        [Route("UpLoadMaintainCardImg")]
        [HttpPost]
        public string UpLoadMaintainCardImg()
        {
            IFormFile formFile = Request.Form.Files[0];
            UploadFilesHelper upload = new UploadFilesHelper(_hostingEnvironment, "/Image/");
            string file = upload.Main(formFile);
            return file;
        }

        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("DelCar")]
        [HttpPost]
        public async Task<IActionResult> DelCarAsync(string id)
        {
            try
            {
                bool data = await _carRegistration.DelCarAsync(id);
                if (data == true)
                    return Ok(new { code = data, meta = 200, msg = "删除成功" });
                else
                    return Ok(new { code = data, meta = 500, msg = "删除失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "删除失败" });
            }
        }

        /// <summary>
        /// 反填车辆信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("EditCar")]
        [HttpGet]
        public async Task<IActionResult> EditCarAsync(int id)
        {
            try
            {
                RegistrationModel data = await _carRegistration.EditCarAsync(id);
                if (data != null)
                    return Ok(new { code = true, meta = 200, msg = "获取成功", data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "获取失败", data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "获取失败", data = "" });
            }
        }

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        [Route("UpdCar")]
        [HttpPost]
        public async Task<IActionResult> UpdCarAsync(RegistrationModel model)
        {
            try
            {
                bool data = await _carRegistration.UpdCarAsync(model);
                if (data == true)
                    return Ok(new { code = data, meta = 200, msg = "修改成功" });
                else
                    return Ok(new { code = data, meta = 500, msg = "修改失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "修改失败" });
            }
        }
    }
}

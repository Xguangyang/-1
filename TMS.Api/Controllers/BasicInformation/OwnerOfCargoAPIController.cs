﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.UpFiles;
using TMS.Model.Entity.BasicInformation;
using TMS.Service.BasicInformation;

namespace TMS.Api.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息-货主管理API
    /// </summary>
    [Route("OwnerOfCargoAPI")]
    [ApiController]
    [Authorize]
    public class OwnerOfCargoAPIController : ControllerBase
    {
        //用户服务
        public readonly IOwnerOfCargoService _owner;

        private readonly IHostingEnvironment _hostingEnvironment;

        //构造函数进行注入
        public OwnerOfCargoAPIController(IOwnerOfCargoService owner, IHostingEnvironment hostingEnvironment)
        {
            _owner = owner;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 显示货主管理
        /// </summary>
        /// <param name="OwnerName">货主名称</param>
        /// <param name="OwnerPhone">货主电话</param>
        /// <param name="DateTime">驾驶证有效日期</param>
        /// <returns></returns>
        [Route("GetOwnerOfCargos")]
        [HttpGet]
        public async Task<IActionResult> GetOwnerOfCargosAsync(string OwnerName = "", string OwnerPhone = "", DateTime? DateTime = null)
        {
            try
            {
                List<OwnerOfCargo> data = await _owner.GetOwnerOfCargosAsync(OwnerName, OwnerPhone, DateTime);
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
        /// 添加货主
        /// </summary>
        /// <param name="Model">货主信息</param>
        /// <returns></returns>
        [Route("AddOwner")]
        [HttpPost]
        public async Task<IActionResult> AddOwnerAsync(OwnerOfCargo Model)
        {
            try
            {
                bool data = await _owner.AddOwnerAsync(Model);
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
        [Route("UpLoadDrivingLicenceTime")]
        [HttpPost]
        public string UpLoadDrivingLicenceTime()
        {
            IFormFile formFile = Request.Form.Files[0];
            UploadFilesHelper upload = new UploadFilesHelper(_hostingEnvironment, "/Image/");
            string file = upload.Main(formFile);
            return file;
        }

        /// <summary>
        /// 删除货主信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DelOwner")]
        [HttpPost]
        public async Task<IActionResult> DelOwnerAsync(string Id)
        {
            try
            {
                bool data = await _owner.DelOwnerAsync(Id);
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
        /// 反填货主信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("EditOwner")]
        [HttpGet]
        public async Task<IActionResult> EditOwnerAsync(int Id)
        {
            try
            {
                OwnerOfCargo data = await _owner.EditOwnerAsync(Id);
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
        /// 修改货主管理
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [Route("UpdOwner")]
        [HttpPost]
        public async Task<IActionResult> UpdOwnerAsync(OwnerOfCargo Model)
        {
            try
            {
                bool data = await _owner.UpdOwnerAsync(Model);
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

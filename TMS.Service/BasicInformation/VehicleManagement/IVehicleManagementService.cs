using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;

namespace TMS.Service.BasicInformation
{
    public interface IVehicleManagementService
    {
        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <returns></returns>
        Task<List<RegistrationModel>> GetCarRegistrationsAsync(string factoryPlate, string carNumber, string carName, string companies);

        /// <summary>
        /// 添加车辆管理
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        Task<bool> AddCarAsync(RegistrationModel model);

        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<bool> DelCarAsync(string id);
        /// <summary>
        /// 反填车辆信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RegistrationModel> EditCarAsync(int id);

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        Task<bool> UpdCarAsync(RegistrationModel model);
    }
}

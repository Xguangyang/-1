using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity;

namespace TMS.Service.BasicInformation
{
    public class VehicleManagementService : IVehicleManagementService
    {
        private readonly IVehicleManagementRepository carRegistration;

        public VehicleManagementService(IVehicleManagementRepository _carRegistration)
        {
            carRegistration = _carRegistration;
        }

        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <param name="factoryPlate">厂牌型号</param>
        /// <param name="carNumber">车牌号</param>
        /// <param name="carName">司机名称</param>
        /// <param name="companies">所属公司</param>
        /// <returns></returns>
        public async Task<List<RegistrationModel>> GetCarRegistrationsAsync(string factoryPlate, string carNumber, string carName, string companies)
        {
            return await carRegistration.GetCarRegistrationsAsync(factoryPlate, carNumber, carName, companies);
        }

        /// <summary>
        /// 添加车辆管理
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        public async Task<bool> AddCarAsync(RegistrationModel model)
        {
            return await carRegistration.AddCarAsync(model);
        }

        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelCarAsync(string id)
        {
            return await carRegistration.DelCarAsync(id);
        }

        /// <summary>
        /// 反填车辆信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RegistrationModel> EditCarAsync(int id)
        {
            return await carRegistration.EditCarAsync(id);
        }

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        public async Task<bool> UpdCarAsync(RegistrationModel model)
        {
            return await carRegistration.UpdCarAsync(model);
        }
    }
}

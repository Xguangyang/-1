using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity;

namespace TMS.Repository.BasicInformation
{
    public class VehicleManagementRepository : IVehicleManagementRepository
    {
        private readonly DapperClientHelper _SqlDB; //数据库连接

        public VehicleManagementRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 显示车辆管理
        /// </summary>
        /// <returns></returns>
        public async Task<List<RegistrationModel>> GetCarRegistrationsAsync(string factoryPlate, string carNumber, string carName, string companies)
        {
            string sql = "select RegistrationID,FactoryPlateModel,LicensePlateNumber,LicensePlateName,LicensePlateLWH,LicensePlateColour,RegistrationImg,SubordinateCompanies,BuyTime,ServiceCertificateNumber,InsuranceExpireTime,AnnualExpireTime,MaintainKilometreSetting,MaintainCardImg from RegistrationModel";

            var data = await _SqlDB.QueryAsync<RegistrationModel>(sql);

            if (!string.IsNullOrEmpty(factoryPlate))//厂牌型号
            {
                data = data.Where(x => x.FactoryPlateModel.Contains(factoryPlate)).ToList();
            }
            if (!string.IsNullOrEmpty(carNumber))//车牌号
            {
                data = data.Where(x => x.LicensePlateNumber.Contains(carNumber)).ToList();
            }
            if (!string.IsNullOrEmpty(carName))//司机名称
            {
                data = data.Where(x => x.LicensePlateName.Contains(carName)).ToList();
            }
            if (!string.IsNullOrEmpty(companies))//所属公司
            {
                data = data.Where(x => x.SubordinateCompanies.Contains(companies)).ToList();
            }
            return data.ToList();
        }

        /// <summary>
        /// 添加车辆管理
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        public async Task<bool> AddCarAsync(RegistrationModel model)
        {
            string sql = "insert into RegistrationModel values(@FactoryPlateModel,@LicensePlateNumber,@LicensePlateName,@LicensePlateLWH,@LicensePlateColour,@RegistrationImg,@SubordinateCompanies,@BuyTime,@ServiceCertificateNumber,@InsuranceExpireTime,@AnnualExpireTime,@MaintainKilometreSetting,@MaintainCardImg)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @FactoryPlateModel = model.FactoryPlateModel,
                @LicensePlateNumber = model.LicensePlateNumber,
                @LicensePlateName = model.LicensePlateName,
                @LicensePlateLWH = model.LicensePlateLWH,
                @LicensePlateColour = model.LicensePlateColour,
                @RegistrationImg = model.RegistrationImg,
                @SubordinateCompanies = model.SubordinateCompanies,
                @BuyTime = model.BuyTime,
                @ServiceCertificateNumber = model.ServiceCertificateNumber,
                @InsuranceExpireTime = model.InsuranceExpireTime,
                @AnnualExpireTime = model.AnnualExpireTime,
                @MaintainKilometreSetting = model.MaintainKilometreSetting,
                @MaintainCardImg = model.MaintainCardImg
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 删除车辆信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelCarAsync(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from RegistrationModel where RegistrationID in (@ID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 反填车辆信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RegistrationModel> EditCarAsync(int id)
        {
            string sql = "select RegistrationID,FactoryPlateModel,LicensePlateNumber,LicensePlateName,LicensePlateLWH,LicensePlateColour,RegistrationImg,SubordinateCompanies,BuyTime,ServiceCertificateNumber,InsuranceExpireTime,AnnualExpireTime,MaintainKilometreSetting,MaintainCardImg from RegistrationModel where RegistrationID=@ID";
            return await _SqlDB.QueryFirstAsync<RegistrationModel>(sql, new { @ID = id });
        }

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="model">车辆信息</param>
        /// <returns></returns>
        public async Task<bool> UpdCarAsync(RegistrationModel model)
        {
            string sql = "update RegistrationModel set FactoryPlateModel=@FactoryPlateModel,LicensePlateNumber=@LicensePlateNumber,LicensePlateName=@LicensePlateName,LicensePlateLWH=@LicensePlateLWH,LicensePlateColour=@LicensePlateColour,RegistrationImg=@RegistrationImg,SubordinateCompanies=@SubordinateCompanies,BuyTime=@BuyTime,ServiceCertificateNumber=@ServiceCertificateNumber,InsuranceExpireTime=@InsuranceExpireTime,AnnualExpireTime=@AnnualExpireTime,MaintainKilometreSetting=@MaintainKilometreSetting,MaintainCardImg=@MaintainCardImg where RegistrationID=@RegistrationID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @RegistrationID = model.RegistrationID,
                @FactoryPlateModel = model.FactoryPlateModel,
                @LicensePlateNumber = model.LicensePlateNumber,
                @LicensePlateName = model.LicensePlateName,
                @LicensePlateLWH = model.LicensePlateLWH,
                @LicensePlateColour = model.LicensePlateColour,
                @RegistrationImg = model.RegistrationImg,
                @SubordinateCompanies = model.SubordinateCompanies,
                @BuyTime = model.BuyTime,
                @ServiceCertificateNumber = model.ServiceCertificateNumber,
                @InsuranceExpireTime = model.InsuranceExpireTime,
                @AnnualExpireTime = model.AnnualExpireTime,
                @MaintainKilometreSetting = model.MaintainKilometreSetting,
                @MaintainCardImg = model.MaintainCardImg
            });
            return code == 0 ? true : false;
        }
    }
}

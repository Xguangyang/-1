using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Setting;

namespace TMS.IRepository.Setting
{
    public interface IPositionRepository
    {
        /// <summary>
        /// 显示职位信息
        /// </summary>
        /// <param name="positionName">职位名称查询</param>
        /// <returns></returns>
        Task<List<Position>> GetPosition(string positionName);
    }
}

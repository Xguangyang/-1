using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Setting;
using TMS.Model.Entity.Setting;

namespace TMS.Service.Setting
{
    public class PositionService: IPositionService
    {
        private readonly IPositionRepository _position;

        public PositionService(IPositionRepository  position)
        {
            _position = position;
        }

        /// <summary>
        /// 显示职位信息
        /// </summary>
        /// <param name="positionName">职位名称查询</param>
        /// <returns></returns>
        public async Task<List<Position>> GetPosition(string positionName)
        {
            return await _position.GetPosition(positionName);
        }


    }
}

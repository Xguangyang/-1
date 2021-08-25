using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.Setting;
using TMS.Model.Entity.Setting;

namespace TMS.Repository.Setting
{
    public class PositionRepository: IPositionRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public PositionRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 显示职位信息
        /// </summary>
        /// <param name="positionName">职位名称查询</param>
        /// <returns></returns>
        public async Task<List<Position>> GetPosition(string positionName)
        {
            string sql = "select * from Position";
            List<Position> data = await _SqlDB.QueryAsync<Position>(sql);
            if (!string.IsNullOrEmpty(positionName))//职位名称查询
            {
                data = data.Where(x => x.PositionName.Contains(positionName)).ToList();
            }
            return data;
        }

    }
}

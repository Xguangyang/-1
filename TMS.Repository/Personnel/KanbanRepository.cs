using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.Personnel;
using TMS.Model.ViewModel;

namespace TMS.Repository.Personnel
{
    public class KanbanRepository: IKanbanRepository
    {
        private readonly DapperClientHelper _SqlDB;//数据库连接

        public KanbanRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 离职人数看板
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> GetLeaveKanban()
        {
            List<int> intList = new List<int>();
            string sql = "select * from V_Leave";
            LeaveKanbanViewModel data = await _SqlDB.QueryFirstAsync<LeaveKanbanViewModel>(sql);
            intList.Add(data.One);
            intList.Add(data.Two);
            intList.Add(data.Three);
            intList.Add(data.Four);
            intList.Add(data.Five);
            intList.Add(data.Six);
            intList.Add(data.Seven);
            intList.Add(data.Eight);
            intList.Add(data.Nine);
            intList.Add(data.Ten);
            intList.Add(data.Eleven);
            intList.Add(data.Twelve);
            return intList;
        }
    }
}

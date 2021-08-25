using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;

namespace TMS.Service.Personnel.Kanban
{
    public interface IKanbanService
    {
        /// <summary>
        /// 离职人数看板
        /// </summary>
        /// <returns></returns>
        Task<List<int>> GetLeaveKanban();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Personnel;
using TMS.Model.ViewModel;

namespace TMS.Service.Personnel.Kanban
{
    public class KanbanService : IKanbanService
    {
        private readonly IKanbanRepository _kanban;

        public KanbanService(IKanbanRepository kanban)
        {
            _kanban = kanban;
        }

        /// <summary>
        /// 离职人数看板
        /// </summary>
        /// <returns></returns>
        public async Task<List<int>> GetLeaveKanban()
        {
            return await _kanban.GetLeaveKanban();
        }
    }
}

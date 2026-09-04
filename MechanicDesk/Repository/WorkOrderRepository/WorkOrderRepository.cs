using MechanicDesk.DataBase;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Repository.WorkOrderRepository
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}

using MechanicDesk.Models;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.DTOs.WorkOrderDTO;

public class CreateWorkOrderDTO
{
    public string ProblemDescription { get; set; } = string.Empty;
    public DateTime InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public string WorkerName { get; set; } = string.Empty;
    public bool IsFinished { get; set; }

    public string LicencePlate { get; set; } = string.Empty;
    public int ClientId { get; set; }
}

using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.DTOs.WorkOrderDTO;

public class UpdateWorkOrderDTO
{
    public int Id { get; set; }
    public string ProblemDescription { get; set; } = string.Empty;
    public DateTime InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public string WorkerName { get; set; } = string.Empty;
    public bool IsFinished { get; set; }
    public int CarId { get; set; }
    public int ClientId { get; set; }
}

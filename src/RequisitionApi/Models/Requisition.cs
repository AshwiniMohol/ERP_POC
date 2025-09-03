namespace RequisitionApi.Models
{
public class Requisition 
{

    public int Id{ get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public DateTime RequestedDate { get; set; }
    public string RequestedBy { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; 
}
}   
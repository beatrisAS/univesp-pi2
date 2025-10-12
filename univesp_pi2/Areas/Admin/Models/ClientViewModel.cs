namespace univesp_pi2.Areas.Admin.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public int TotalOrders { get; set; }
    }
}
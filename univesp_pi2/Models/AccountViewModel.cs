using System.Collections.Generic;

namespace univesp_pi2.Models
{
    public class AccountViewModel
    {
        public ProfileViewModel Profile { get; set; } = new();
        public List<OrderViewModel> Orders { get; set; } = new();
        public List<AddressViewModel> Addresses { get; set; } = new();

     
        public List<SupplierOrderViewModel> SupplierOrders { get; set; } = new();
    }
}
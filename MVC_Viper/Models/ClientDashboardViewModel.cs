using System.Runtime.CompilerServices;

namespace MVC_Viper.Models
{
    public class ClientDashboardViewModel
    {
        public string PhoneNumber { get; set; }
        public string Program { get; set; }
        public string? ProgramBenefits { get; set; }
        public decimal ProgramCharge { get; set; }
        public List<Call> CallHistory { get; set; }
        public decimal CurrentBill { get; set; }
    }
}

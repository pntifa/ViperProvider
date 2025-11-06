using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class ClientsMetaData
    {
        [Display(Name = "AFM")]
        public string? Afm { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}

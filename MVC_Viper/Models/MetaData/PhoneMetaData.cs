using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class PhoneMetaData
    {
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Program Name")]
        public virtual Programs? ProgramNameNavigation { get; set; }
    }
}

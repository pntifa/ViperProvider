using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class BillMetaData
    {
        [Display(Name =" Bill Costs")]
        public decimal? Costs { get; set; }

        [Display(Name =" Phone Number")]
        public virtual Phone? PhoneNumberNavigation { get; set; }
    }
}

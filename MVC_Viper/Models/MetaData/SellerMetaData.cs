using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class SellerMetaData
    {
        [Display(Name = "Seller Name")]
        public virtual User? User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class CallsMetaData
    {
        [Display(Name =" Description of Call")]
        public string? Description { get; set; }
    }
}

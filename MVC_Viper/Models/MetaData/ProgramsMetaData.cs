using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class ProgramsMetaData
    {
        [Display(Name = "Program Name")]
        public string ProgramName { get; set; } = null!;
        [Display(Name = "Benefits of Program")]
        public string? Benefits { get; set; }
        [Display(Name = "Charge")]
        public decimal? Charge { get; set; }
    }
}

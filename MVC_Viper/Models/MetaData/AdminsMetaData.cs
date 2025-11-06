using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class AdminsMetaData
    {
        [Display(Name = "Users who are Admins")]
        public virtual User? User { get; set; }
    }
}


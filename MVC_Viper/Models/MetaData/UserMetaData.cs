using System.ComponentModel.DataAnnotations;

namespace MVC_Viper.Models.MetaData
{
    public class UserMetaData
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Username")]
        public string? Username { get; set; }
        [Display(Name = "Property")]
        public string? Property { get; set; }
        [Display(Name = "Password")]
        public byte[] PasswordHash { get; set; } = null!;
    }
}

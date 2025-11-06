using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("admin")]
public partial class Admin
{
    [Key]
    [Column("Admin_Id")]
    public int AdminId { get; set; }

    [Column("User_Id")]
    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Admins")]
    public virtual User? User { get; set; }
}

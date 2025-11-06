using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("sellers")]
public partial class Seller
{
    [Key]
    [Column("Seller_Id")]
    public int SellerId { get; set; }

    [Column("User_Id")]
    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Sellers")]
    public virtual User? User { get; set; }
}

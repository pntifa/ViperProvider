using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("clients")]
public partial class Client
{
    [Key]
    [Column("Client_Id")]
    public int ClientId { get; set; }

    [Column("AFM")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Afm { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("User_Id")]
    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Clients")]
    public virtual User? User { get; set; }
}

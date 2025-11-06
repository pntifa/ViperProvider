using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("users")]
public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("User_Id")]
    public int UserId { get; set; }

    [Column("First_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("Last_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Property { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [InverseProperty("User")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("User")]
    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}

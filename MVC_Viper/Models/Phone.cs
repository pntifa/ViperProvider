using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("phones")]
public partial class Phone
{
    [Key]
    [StringLength(50)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("Program_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProgramName { get; set; }

    [InverseProperty("PhoneNumberNavigation")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [ForeignKey("ProgramName")]
    [InverseProperty("Phones")]
    public virtual Programs? ProgramNameNavigation { get; set; }
}

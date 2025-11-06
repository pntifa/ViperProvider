using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("calls")]
public partial class Call
{
    [Key]
    [Column("Call_ID")]
    public int CallId { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [ForeignKey("CallId")]
    [InverseProperty("Calls")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}

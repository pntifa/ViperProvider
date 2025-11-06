using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

[Table("bills")]
public partial class Bill
{
    [Key]
    [Column("Bill_ID")]
    public int BillId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal? Costs { get; set; }

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Bills")]
    public virtual Phone? PhoneNumberNavigation { get; set; }

    [ForeignKey("BillId")]
    [InverseProperty("Bills")]
    public virtual ICollection<Call> Calls { get; set; } = new List<Call>();
}

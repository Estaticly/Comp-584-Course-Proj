using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShoeExplorerModel;

public partial class Brand
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("brandName")]
    [StringLength(50)]
    public string BrandName { get; set; } = null!;

    [Column("shoeCount")]
    public int ShoeCount { get; set; }

    [InverseProperty("BrandNavigation")]
    public virtual ICollection<Shoe> Shoes { get; } = new List<Shoe>();
}

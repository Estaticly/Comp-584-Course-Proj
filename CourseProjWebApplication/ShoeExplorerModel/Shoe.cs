using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShoeExplorerModel;

public partial class Shoe
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("brand")]
    [StringLength(50)]
    public string Brand { get; set; } = null!;

    [Column("model")]
    [StringLength(50)]
    public string Model { get; set; } = null!;

    [Column("size")]
    public int Size { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("brandId")]
    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    [InverseProperty("Shoes")]
    public virtual Brand BrandNavigation { get; set; } = null!;
}

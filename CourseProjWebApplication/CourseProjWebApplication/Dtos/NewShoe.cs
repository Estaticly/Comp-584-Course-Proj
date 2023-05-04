using ShoeExplorerModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseProjWebApplication.Dtos
{
    public partial class NewShoe
    {
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
  
    }
}
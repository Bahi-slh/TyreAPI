using System.ComponentModel.DataAnnotations;

namespace TyreManagementAPI.Models.Entities
{
    public class Tyre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
    }
}


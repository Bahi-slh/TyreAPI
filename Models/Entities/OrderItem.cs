using System.ComponentModel.DataAnnotations;

namespace TyreManagementAPI.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int TyreId { get; set; }
        public Tyre Tyre { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}

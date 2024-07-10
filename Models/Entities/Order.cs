using System.ComponentModel.DataAnnotations;

namespace TyreManagementAPI.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}

namespace TyreManagementAPI.Models.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }

    public class CreateOrderItemDto
    {
        public int TyreId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateOrderDto
    {
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public List<UpdateOrderItemDto> OrderItems { get; set; }
    }

    public class UpdateOrderItemDto
    {
        public int Id { get; set; }
        public int TyreId { get; set; }
        public int Quantity { get; set; }
    }
}

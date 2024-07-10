namespace TyreManagementAPI.Models.DTOs
{
    public class CreateTyreDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
    public class UpdateTyreDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
    }
}

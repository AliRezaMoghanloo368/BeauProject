namespace BeauProject.Restaurant.Application.DTOs.Restaurant
{
    public class RestaurantDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string DefaultCurrency { get; set; } = "IRR"; // کد ISO 4217
        public string? TimeZone { get; set; } = "Asia/Tehran"; // 🕒 بر اساس استاندارد IANA
    }
}

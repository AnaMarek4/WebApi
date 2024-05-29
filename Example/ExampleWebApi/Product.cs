using System.Text.Json.Serialization;

namespace ExampleWebApi
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string? Description { get; set; }

    }
}

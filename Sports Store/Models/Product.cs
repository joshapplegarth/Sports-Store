using System.ComponentModel.DataAnnotations.Schema;

namespace Sports_Store.Models
{
    [Table("Product")] // how to name table in DB if different from AppDBContext
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(8, 2)")] // 8 total digits, 2 decimal places
        public decimal Price { get; set; }

        public string Category { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace VodusResearch.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 99999.99, ErrorMessage = "Price is required")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
    }
}

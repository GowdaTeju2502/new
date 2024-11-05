using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace E_commerce.Database.Entity
{
    public class Electronic_Product
    {
        [Key]
        public int Product_Id {  get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public string Product_Description { get; set; }
        [Required]
        public int Product_Price { get; set; }
        [Required]
        public string Seller_Name {  get; set; }
        [Required]

        public string ImagePath { get; set; }
        [NotMapped] // Indicates that this property should not be included in the database schema
        [Required]
        public IFormFile ImageFile { get; set; } // File uploaded by the user
        [Required]

        public int Ratings {  get; set; }




    }
}

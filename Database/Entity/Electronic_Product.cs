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
        public string Seller_Name { get; set; }
        [Required]

        public string ImagePath { get; set; }
        [NotMapped] // Indicates that this property should not be included in the database schema
        
        public IFormFile ImageFile { get; set; } // File uploaded by the user
        [Required]

        public int Ratings {  get; set; }
        public int Battery_capacity { get; set; }
        [Required]
        public int RAM { get; set; }
        [Required]
        public int ROM { get; set; }

        [Required]
        public string Operating_System { get; set; }
        [Required]
        public string Brand { get; set; }

        public int Product_Quantity { get; set; }

        //[Required]
        public int Seller_Id { get; set; }
        // public Review Reviews { get; set; }
        //public ICollection<Review> Reviews { get; set; }
        //public Electronic_Product Product { get; set; }


    }
}

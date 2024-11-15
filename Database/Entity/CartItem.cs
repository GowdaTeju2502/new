using System.ComponentModel.DataAnnotations;

namespace E_commerce.Database.Entity
{
    public class CartItem
    {
        [Key]
        public int CartItem_Id { get; set; }

        // Foreign Key to Cart
        [Required]
        public int Cart_Id { get; set; }
        public Cart Cart { get; set; }

        // Foreign Key to Product
        [Required]
        public int Product_Id { get; set; }
        public Electronic_Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }

      
    }

}

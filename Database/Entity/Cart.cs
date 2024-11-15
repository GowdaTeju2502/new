using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace E_commerce.Database.Entity
{
    public class Cart
    {
        [Key]
        public int Cart_Id { get; set; }

        // Foreign Key to the Customer
        [Required]
        public string Customer_Email { get; set; }
        [Required]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }

        // Navigation property to CartItems
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }



}


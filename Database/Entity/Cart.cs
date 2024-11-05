using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace E_commerce.Database.Entity
{
    public class Cart
    {
        [Key] 
        public int Cart_Id { get; set; }
        [Required]
        public int Product_Id {  get; set; }
        [Required]
        public int Product_Price { get; set; }
        [Required]
        public int Total_Amount { get; set; }
        [Required]

        public int Quantity {  get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace E_commerce.Database.Entity
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        [Required]
        public DateTime Ordered_Date { get; set; }
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public int Customer_Id { get; set; }
        [Required]

        public int Seller_Id { get; set; }
        [Required]
        public int Ordered_Quantity { get; set; }
        public Electronic_Product product { get; set; }
        public Customer Customers { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace E_commerce.Database.Entity
{
    public class Seller
    {
        [Key]
        public int Seller_Id { get; set; }
        [Required]
        public string Seller_Name { get;set; }
        [Required]
        [Phone]
        public string Seller_Contact { get; set; }
        [Required]

        public string Seller_Address { get; set; }
        [Required]
        [EmailAddress]
        public string Seller_Email { get; set; }
        [Required]
        public string Seller_Gender { get; set; }
        [Required]
        public string Seller_DOB { get; set; }
        [Required]

        public string Seller_Password {  get; set; }
        [Required]

        public string Seller_ConfirmPassword {  get; set; }
        [Required]

        public string Seller_State {  get; set; }
        [Required]
        public string Seller_District {  get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Seller_Pincode { get; set; }
        [Required]

        public int Seller_isactive { get; set; } = 1;
        public bool IsApproved { get; set; }=false;

        //public List<Electronic_Product> Electronics { get; set; }
    }
}

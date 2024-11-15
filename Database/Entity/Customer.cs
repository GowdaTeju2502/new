using System.ComponentModel.DataAnnotations;

namespace E_commerce.Database.Entity
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        [Required]
    
        public string Customer_Name { get; set; }

        [Required]
        [Phone]
        public string Customer_Contact { get; set; }

        [Required]

        public string Customer_Address { get; set; }

        [Required]
        [EmailAddress]
    
        public string Customer_Email { get; set; }

        [Required]
      
        public string Customer_Gender { get; set; }

        [Required]
   
        public string Customer_DOB { get; set; }

        [Required]
   
        public string Customer_Password { get; set; }

        [Required]
    
        public string Customer_ConfirmPassword { get; set; }

        [Required]
        public string Customer_State { get; set; }

        [Required]
        public string Customer_District { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Customer_Pincode { get; set; }
        [Required]

        public string Customer_Landmark {  get; set; }

        [Required]
        public int Customer_IsActive { get; set; } = 1;
        //public Review Reviews { get; set; }
    }
}

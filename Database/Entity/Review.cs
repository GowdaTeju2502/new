using System;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Database.Entity
{
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }


        public int Product_Id { get; set; }

        public int Customer_Id { get; set; }

        public string Review_Text { get; set; }
        public int Rating { get; set; }  // Rating from 1 to 5
        public DateTime Review_Date { get; set; }

        //internal List<Review> ToList()
        //{
        //    throw new NotImplementedException();
        //}

        // public Customer customers { get; set; }
        //public int Customer_Id { get; set; }
        //public Customer Customers { get; set; }
        //public ICollection<Review> Reviews { get; set; }


    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace QuotesApplication.Models
{
	
	
        public class Customer
        {
            [Key]
            public int CustomerId { get; set; }
        

            public string CustomerName { get; set; }

            public string Desgination { get; set; }
            
            public string Address { get; set; }
            
            public string CompanyName { get; set; }

           [Required]
           [EmailAddress]
           public string Email { get; set; }

           [Required]
           [StringLength(10)]
           public string PhoneNumber { get; set; }

           [Required]
           [StringLength(15)]
           public string TaxNumber { get; set; }
    }
    
}


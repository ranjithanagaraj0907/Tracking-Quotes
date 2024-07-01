using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotesApplication.Models
{
	public class QuotesModel
	{
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //Foreign key property By staff table
        [ForeignKey("StaffsModels")]
        public int StaffID { get; set; }

        // Foreign key property by customer table
        [ForeignKey("Customer")]
        public int CustomerID{ get; set; }

        public DateTime ReceviedDtae { get; set; }

        public IEnumerable<Quoteitem> quoteitem { get; set; }
    }
    
}


using System;
using System.ComponentModel.DataAnnotations;

namespace QuotesApplication.Models
{
	public class StaffsModels
	{
		[Key]
        public int StaffID { get; set; }

        public string StaffName { get; set; }

		public string Desgination { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
	}
}


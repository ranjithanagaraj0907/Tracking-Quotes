using System;
using System.ComponentModel.DataAnnotations;

namespace QuotesApplication.Models
{
    public class Quoteitem
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Itemcode { get; set; }
        public int Quantityrequested { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Stock Name")]
        [StringLength(100, ErrorMessage = "Stock Name Should not be Less than 5 or more than 100 characters", MinimumLength = 5)]
        public string StockName { get; set; }

        [Required, Display(Name = "Stock Symbol")]
        [StringLength(15, ErrorMessage = "Stock Symbol Should not be Less than 2 or more than 15 characters", MinimumLength = 2)]
        public string StockSymbol { get; set; }

        [Required, Display(Name = "Entry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required, Display(Name = "Entry User Id")]
        public int EntryUserId { get; set; }
    }
}

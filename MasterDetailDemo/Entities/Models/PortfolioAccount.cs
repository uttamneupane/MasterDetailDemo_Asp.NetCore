using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("PortfolioAccount")]
    public class PortfolioAccount
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Account No.")]
        [StringLength(20, ErrorMessage = "Account Number should not be less than 5 or more than 20 characters ", MinimumLength = 5)]
        public string AccountNumber { get; set; }

        [Required, Display(Name = "Account Name")]
        [StringLength(50, ErrorMessage = "Account Name should not be less than 5 or more than 50 characters ", MinimumLength = 5)]
        public string AccountName { get; set; }

        [Required, Display(Name = "Entry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required, Display(Name = "Entry User Id")]
        public int EntryUserId { get; set; }
    }
}

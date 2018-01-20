using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("StockReceiveMast")]
    public class StockReceiveMast
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Entry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required, Display(Name = "Entry User Id")]
        public int EntryUserId { get; set; }

        [Required, Display(Name = "Remarks")]
        [StringLength(100, ErrorMessage = "Remarks should not be less than 5 or more than 100 characters", MinimumLength = 5)]
        public string Remarks { get; set; }


        [Required, Display(Name = "Value Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime ValueDate { get; set; }

        //foreignKey relation

        public int PortfolioAcId { get; set; }
        [ForeignKey("PortfolioAcId")]
        public virtual PortfolioAccount PortfolioAccount { get; set; }

        public List<StockReceiveDetl> Detail { get; set; }

    }
}

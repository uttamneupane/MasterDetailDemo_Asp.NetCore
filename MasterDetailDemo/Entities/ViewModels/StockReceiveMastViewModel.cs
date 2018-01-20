using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ViewModels
{
    public class StockReceiveMastViewModel
    {
        public int Id { get; set; }
        public int PortfolioAcId { get; set; }

        [Required, Display(Name = "Value Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime ValueDate { get; set; }

        public string PortfolioAccountNumber { get; set; }

        [Required]
        public string PortfolioAccountName { get; set; }


        [Required, Display(Name = "Remarks")]
        [StringLength(100, ErrorMessage = "Remarks should not be less than 5 or more than 100 characters", MinimumLength = 5)]
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTime EntryDate { get; set; }
        public string UserName { get; set; }
        public List<StockReceiveDetlViewModel> details { get; set; }
    }
}

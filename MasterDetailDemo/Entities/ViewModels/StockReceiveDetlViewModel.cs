using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ViewModels
{
    public class StockReceiveDetlViewModel
    {
        public int Id { get; set; }
        public int MastId { get; set; }
        public int StockId { get; set; }

        public string StockName { get; set; }

        [Required, Display(Name = "Ownership Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime OwnerShipDate { get; set; }

        [Required, Display(Name = "Quantity"), Range(1, 999999999, ErrorMessage = "Quantity cann't be less than 1 or more than 999999999")]
        public int Quantity { get; set; }

        [Required, Display(Name = "Rate")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Rate { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        New = 0,
        Old = 1
    }
}


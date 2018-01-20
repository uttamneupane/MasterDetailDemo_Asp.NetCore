using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("StockReceiveDetl")]
    public class StockReceiveDetl
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Quantity"), Range(1, 999999999, ErrorMessage = "Quantity cann't be less than 1 or more than 999999999")]
        [Column("Qty")]
        public int Quantity { get; set; }

        [Required, Display(Name = "Rate")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Rate { get; set; }

        [Required, Display(Name = "Ownership Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}"), DataType(DataType.Date)]
        public DateTime OwnershipDate { get; set; }

        //foreignKey relations

        public int MastId { get; set; }
        [ForeignKey("MastId")]
        public virtual StockReceiveMast StockReceiveMast { get; set; }

        public int StockId { get; set; }
        [ForeignKey("StockId")]
        public virtual Stock Stock { get; set; }
    }
}

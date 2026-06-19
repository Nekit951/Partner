using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Models
{
    [Table("Sale")]
    public class Sale
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Column("Partner")]
        public Int32? partner { get; set; }

        [Column("Product")]
        public Int32? product { get; set; }

        [Column("Data")]
        public DateTime? data { get; set; }

        [Column("Quantity")]
        public Int32? quantity { get; set; }

        [Column("Amount")]
        public Decimal? amount { get; set; }
    }
}

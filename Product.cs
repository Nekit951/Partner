using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public String name { get; set; }

        [Column("Price")]
        public Decimal? price { get; set; }
    }
}

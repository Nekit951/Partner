using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Models
{
    [Table("Partner")]
    public class Partner
    {
        [Key]
        [Column("Id")]
        public int id { get; set; }

        [Column("Company")]
        public String company { get; set; }

        [Column("Inn")]
        public String inn { get; set; }

        [Column("Phone")]
        public String phone { get; set; }

        [Column("Email")]
        public String email { get; set; }

        [Column("PartnerType")]
        public string partnerType { get; set; } 

        [Column("DirectorName")]
        public string directorName { get; set; }

        [Column("Rating")]
        public int rating { get; set; }

        [NotMapped]
        public string DisplayTitle => $"{partnerType} | {company}";

        [NotMapped]
        public int currentDiscount { get; set; }
    }
}

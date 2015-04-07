namespace AnketaApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anketa")]
    public partial class Anketa
    {
        [Key]
        public long ankt_brj { get; set; }

        [Required]
        [StringLength(50)]
        public string ankt_naslov { get; set; }

        public long ankt_brjpit { get; set; }

        public long ankt_brjotvaranja { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ankt_datumotv { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ankt_datposljotv { get; set; }
    }
}

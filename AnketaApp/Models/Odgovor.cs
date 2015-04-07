namespace AnketaApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Odgovor")]
    public partial class Odgovor
    {
        [Key]
        public long odg_brj { get; set; }

        [Required]
        [StringLength(50)]
        public string odg_sadr { get; set; }

        public long odg_pitbrj { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? odg_datumpost { get; set; }

        public long? odg_brojodabira { get; set; }
    }
}

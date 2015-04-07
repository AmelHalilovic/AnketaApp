namespace AnketaApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pitanje")]
    public partial class Pitanje
    {
        [Key]
        public long pit_brj { get; set; }

        [Required]
        [StringLength(50)]
        public string pit_sadrz { get; set; }

        public long pit_anktbrj { get; set; }

        [Required]
        [StringLength(250)]
        public string odg1 { get; set; }

        public long odg1_glas { get; set; }

        
        [Required]
        [StringLength(250)]
        public string odg2 { get; set; }

        public long odg2_glas { get; set; }


        [Required]
        [StringLength(250)]
        public string odg3 { get; set; }

        public long odg3_glas { get; set; }

        
        [Required]
        [StringLength(250)]
        public string odg4 { get; set; }
       
        public long odg4_glas { get; set; }

        public long brojotvaranja { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? pit_datumpost { get; set; }
    }
}

namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proprietor")]
    public partial class Proprietor
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProprietorName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public int Cashflow { get; set; }

        public Guid? TheatreId { get; set; }

        public virtual Theatre Theatre { get; set; }
    }
}

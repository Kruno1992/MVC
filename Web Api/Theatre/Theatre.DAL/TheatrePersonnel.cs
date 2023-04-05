namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheatrePersonnel")]
    public partial class TheatrePersonnel
    {
        public Guid Id { get; set; }

        public Guid TheatreId { get; set; }

        public Guid PersonnelId { get; set; }

        public int Paycheck { get; set; }

        public int Clocking { get; set; }

        public int Earnings { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual Theatre Theatre { get; set; }
    }
}

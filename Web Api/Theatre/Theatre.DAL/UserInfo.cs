namespace Theatre.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserInfoName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public virtual Users Users { get; set; }
    }
}

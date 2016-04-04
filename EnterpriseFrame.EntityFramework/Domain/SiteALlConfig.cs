namespace EnterpriseFrame.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteALlConfig")]
    public partial class SiteALlConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigID { get; set; }

        [StringLength(100)]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}

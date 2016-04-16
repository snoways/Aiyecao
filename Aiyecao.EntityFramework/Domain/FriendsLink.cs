namespace Aiyecao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FriendsLink")]
    public partial class FriendsLink
    {
        [Key]
        public int LinkID { get; set; }

        [StringLength(100)]
        public string LinkTitle { get; set; }

        [StringLength(300)]
        public string LinkUrl { get; set; }

        public bool? IsShow { get; set; }

        public int? Top { get; set; }
    }
}

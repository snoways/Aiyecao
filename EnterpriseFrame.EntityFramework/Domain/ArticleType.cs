namespace EnterpriseFrame.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleType")]
    public partial class ArticleType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArticleType()
        {
            ArticleInfoes = new HashSet<ArticleInfo>();
        }

        [Key]
        public int TypeID { get; set; }

        [StringLength(20)]
        public string TypeName { get; set; }

        public string TypeDesc { get; set; }

        public int? ParentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleInfo> ArticleInfoes { get; set; }
    }
}

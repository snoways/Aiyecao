namespace EnterpriseFrame.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleInfo")]
    public partial class ArticleInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArticleInfo()
        {
            ArticleRelations = new HashSet<ArticleRelation>();
        }

        [Key]
        public int ArtID { get; set; }

        public int? TypeID { get; set; }

        [StringLength(300)]
        public string ArtTitle { get; set; }

        public string ArtDesc { get; set; }

        [Column(TypeName = "text")]
        public string ArtContent { get; set; }

        [StringLength(20)]
        public string ArtAuthor { get; set; }

        public bool? ArtState { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ReleaseTime { get; set; }

        [StringLength(300)]
        public string ArtImgUrl { get; set; }

        [StringLength(300)]
        public string ArtTags { get; set; }

        [StringLength(300)]
        public string ArtSource { get; set; }

        public virtual ArticleType ArticleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleRelation> ArticleRelations { get; set; }
    }
}

namespace Aiyecao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleRelation")]
    public partial class ArticleRelation
    {
        [Key]
        public int RelationID { get; set; }

        public int? ArtID { get; set; }

        public int? BrowseNum { get; set; }

        public int? ZambiaNum { get; set; }

        public virtual ArticleInfo ArticleInfo { get; set; }
    }
}

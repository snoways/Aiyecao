namespace Aiyecao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteMessage")]
    public partial class SiteMessage
    {
        [Key]
        public int MsgID { get; set; }

        [StringLength(20)]
        public string MsgUserName { get; set; }

        [StringLength(20)]
        public string MsgPhone { get; set; }

        [StringLength(20)]
        public string MsgQQ { get; set; }

        [Column(TypeName = "text")]
        public string MsgContent { get; set; }

        [Column(TypeName = "text")]
        public string MsgReply { get; set; }

        public bool? MsgIsShow { get; set; }

        public DateTime? MsgTime { get; set; }

        public DateTime? ReplyTime { get; set; }

        [StringLength(20)]
        public string IP { get; set; }
    }
}

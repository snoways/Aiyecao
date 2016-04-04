namespace EnterpriseFrame.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        public int AdminID { get; set; }

        public int? RoleID { get; set; }
        /// <summary>
        /// 管理员名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string AdminName { get; set; }
        /// <summary>
        /// 管理员密码
        /// </summary>
        [Required]
        [StringLength(20)]
        public string AdminPwd { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LoginCount { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsEnable { get; set; }

        public virtual Role Role { get; set; }
    }
}

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
        /// ����Ա����
        /// </summary>
        [Required]
        [StringLength(20)]
        public string AdminName { get; set; }
        /// <summary>
        /// ����Ա����
        /// </summary>
        [Required]
        [StringLength(20)]
        public string AdminPwd { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        public int? LoginCount { get; set; }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool? IsEnable { get; set; }

        public virtual Role Role { get; set; }
    }
}

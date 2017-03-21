using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.Models
{
    /// <summary>
    /// 报名记录
    /// </summary>
    public class Record
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 岗位ID
        /// </summary>
        public long JobId { get; set; }

        /// <summary>
        /// 审核人ID
        /// </summary>
        public long CheckId { get; set; }

        /// <summary>
        /// 报名时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 报名状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime CheckTime { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string Memo { get; set; }
    }
}

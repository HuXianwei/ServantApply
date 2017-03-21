using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.Models
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class Job
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public long CreaterId { get; set; }

        /// <summary>
        /// 岗位名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 岗位描述
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 所在单位
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 年龄限制
        /// </summary>
        public string ageAsk { get; set; }

        /// <summary>
        /// 性别限制
        /// </summary>
        public int sexAsk { get; set; }

        /// <summary>
        /// 学历限制
        /// </summary>
        public int educationAsk { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}

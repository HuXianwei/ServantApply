using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public long Id { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public long CreaterId { get; set; }

        /// <summary>
        /// 岗位名
        /// </summary>
        [Required(ErrorMessage = "岗位名必填")]
        public string Name { get; set; }

        /// <summary>
        /// 岗位描述
        /// </summary>
        [Required(ErrorMessage = "岗位描述必填")]
        public string Content { get; set; }

        /// <summary>
        /// 所在单位
        /// </summary>
        [Required(ErrorMessage = "所属单位必填")]
        public string Organization { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "所在地址必填")]
        public string Address { get; set; }

        /// <summary>
        /// 年龄限制
        /// </summary>
        [Required(ErrorMessage = "年龄限制必填")]
        public string AgeAsk { get; set; }

        /// <summary>
        /// 性别限制
        /// </summary>
        [Required(ErrorMessage = "性别限制必填")]
        public int SexAsk { get; set; }

        /// <summary>
        /// 学历限制
        /// </summary>
        [Required(ErrorMessage = "学历限制必填")]
        public int EducationAsk { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}

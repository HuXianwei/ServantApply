using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.Models
{
    /// <summary>
    /// 考生信息
    /// </summary>
    public class Candidate
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
        /// 真实姓名
        /// </summary>
        [Required(ErrorMessage = "真实姓名不能为空")]
        public string TrueName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required(ErrorMessage = "电话不能为空")]
        public string Tell { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        public string Address { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        [Required(ErrorMessage = "学校不能为空")]
        public string School { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Required(ErrorMessage = "年龄不能为空")]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "性别不能为空")]
        public int Sex { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "身份证号不能为空")]
        public string Card { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Required(ErrorMessage = "民族不能为空")]
        public string Nation { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [Required(ErrorMessage = "政治面貌不能为空")]
        public int Politics { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [Required(ErrorMessage = "学历不能为空")]
        public int Education { get; set; }
    }
}

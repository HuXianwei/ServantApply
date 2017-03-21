using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.Enums
{
    /// <summary>
    /// 学历枚举
    /// </summary>
    public enum EducationType
    {
        /// <summary>
        /// 中专
        /// </summary>
        Secondary = 1,
        /// <summary>
        /// 大专
        /// </summary>
        Firstary = 2,
        /// <summary>
        /// 本科
        /// </summary>
        College = 3,
        /// <summary>
        /// 硕士
        /// </summary>
        Master = 4,
        /// <summary>
        /// 博士
        /// </summary>
        Doctor = 5
    }
    public static class EducationTypeExtension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(this EducationType type)
        {
            switch (type)
            {
                case EducationType.Secondary: return "中专";
                case EducationType.Firstary: return "大专";
                case EducationType.College: return "本科";
                case EducationType.Master: return "硕士";
                case EducationType.Doctor: return "博士";
                default: return "";
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetValue(this EducationType type)
        {
            return (int)type;
        }
    }
}


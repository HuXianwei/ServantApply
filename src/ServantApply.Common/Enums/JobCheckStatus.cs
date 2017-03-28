using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.Enums
{
    /// <summary>
    /// 报告审核状态
    /// </summary>
    public enum JobCheckStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        WaitCheck = 1,
        /// <summary>
        /// 审核通过
        /// </summary>
        CheckSuccess = 2,
        /// <summary>
        /// 审核不通过
        /// </summary>
        CheckFail = 3
    }

    public static class JobCheckStatusExtension
    {
        public static string GetDescription(this JobCheckStatus status)
        {
            switch (status)
            {
                case JobCheckStatus.WaitCheck: return "待审核";
                case JobCheckStatus.CheckSuccess: return "审核通过";
                case JobCheckStatus.CheckFail: return "审核不通过";
                default: return "";
            }
        }

        public static int GetVaule(this JobCheckStatus status)
        {
            return (int)status;
        }
    }
}

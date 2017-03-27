using Microsoft.AspNetCore.Mvc;
using ServantApply.Common;
using ServantApply.Common.Enums;
using ServantApply.Common.IManagers;
using ServantApply.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.WebApp.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordManager recordManager;
        public RecordController(IRecordManager recordManager)
        {
            this.recordManager = recordManager;
        }

        /// <summary>
        /// 获取待审核的岗位列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CheckJobList(int status)
        {
            var list = await recordManager.GetRecordsAsync(status);
            ViewData["WaitCount"] = await recordManager.GetRecordCountAsync((int)JobCheckStatus.WaitCheck);
            ViewData["SuccessCount"] = await recordManager.GetRecordCountAsync((int)JobCheckStatus.CheckSuccess);
            ViewData["FailCount"] = await recordManager.GetRecordCountAsync((int)JobCheckStatus.CheckFail);
            ViewData["Status"] = status;
            return View(list);
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public async Task<IActionResult> CheckJobSuccess(long id, string memo)
        {
            ReturnResult result = await recordManager.CheckRecordAsync(id, memo, HttpContext.User.Identity.Uid(), (int)JobCheckStatus.CheckSuccess);
            return Json(result);
        }

        /// <summary>
        /// 审核不通过
        /// </summary>
        /// <param name="id"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public async Task<IActionResult> CheckJobFail(long id, string memo)
        {
            ReturnResult result = await recordManager.CheckRecordAsync(id, memo, HttpContext.User.Identity.Uid(), (int)JobCheckStatus.CheckFail);
            return Json(result);
        }
    }
}

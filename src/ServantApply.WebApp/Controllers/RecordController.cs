using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServantApply.Common;
using ServantApply.Common.Enums;
using ServantApply.Common.IManagers;
using ServantApply.Common.Models;
using ServantApply.Common.ViewModels;
using ServantApply.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.WebApp.Controllers
{
    [Authorize]
    public class RecordController : Controller
    {
        private readonly IRecordManager recordManager;
        private readonly IJobManager jobManager;
        private readonly ICandidateManager candidateManager;
        public RecordController(IRecordManager recordManager, IJobManager jobManager, ICandidateManager candidateManager)
        {
            this.recordManager = recordManager;
            this.jobManager = jobManager;
            this.candidateManager = candidateManager;
        }

        /// <summary>
        /// 获取待审核的岗位列表
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "System")]
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
        [Authorize(Roles = "System")]
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
        [Authorize(Roles = "System")]
        public async Task<IActionResult> CheckJobFail(long id, string memo)
        {
            ReturnResult result = await recordManager.CheckRecordAsync(id, memo, HttpContext.User.Identity.Uid(), (int)JobCheckStatus.CheckFail);
            return Json(result);
        }

        /// <summary>
        /// 我的报考记录
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyRecord()
        {
            var userId= HttpContext.User.Identity.Uid();
            List<RecordModel> list = await recordManager.GetRecord(userId);
            return View("MyRecord",list);
        }

        /// <summary>
        /// 查看岗位详情
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewJob(long jobId)
        {
            var job = await jobManager.GetDetails(jobId);
            return View("Details", job);
        }

        /// <summary>
        /// 查看考生详情
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewUser(long userId)
        {
            var candidate = await candidateManager.GetCandidate(userId);
            return View("UserMessage", candidate);
        }

        /// <summary>
        /// 打印准考证
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PrintMessage(long recordId)
        {
            CandidateModel candidateModel = await recordManager.PrintMessage(recordId);
            return View("PrintMessage", candidateModel);
        }
    }
}

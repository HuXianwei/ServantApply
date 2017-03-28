using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServantApply.Common;
using ServantApply.Common.IManagers;
using ServantApply.Common.Models;
using ServantApply.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.WebApp.Controllers
{
    [Authorize]
    public class CandidateController:Controller
    {
        private readonly ICandidateManager candidateManager;
        private readonly IRecordManager recordManager;
        public CandidateController(ICandidateManager candidateManager,IRecordManager recordManager)
        {
            this.candidateManager = candidateManager;
            this.recordManager = recordManager;
        }
        /// <summary>
        /// 报考
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Enter(long jobId)
        {
            ReturnResult result = new ReturnResult();
            var id = HttpContext.User.Identity.Uid();
            Candidate candidate = await candidateManager.GetCandidate(id);
            if (candidate == null)
            {
                result.IsSuccess = false;
            }else
            {
                Record record = new Record();
                record.UserId = candidate.UserId;
                record.JobId = jobId;
                await recordManager.Create(record);
            }
            return Json(result);
            //ViewData["jobId"] = jobId;
            //return View("Message");
        }
        /// <summary>
        /// 显示填写个人信息界面
        /// </summary>
        /// <returns></returns>

        public IActionResult Message()
        {
            return View();
        }
        /// <summary>
        /// 个人报考信息管理
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PersonMessage()
        {
            var id = HttpContext.User.Identity.Uid();
            var candidate = await candidateManager.GetCandidate(id);
            if (candidate == null)
            {
                return View("Message");
            }else
            {
                return View("PersonMessage", candidate);
            }
        }
        /// <summary>
        /// 增添个人报考信息
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>

        public async Task<IActionResult> Create(Candidate candidate)
        {
            var id = HttpContext.User.Identity.Uid();
            candidate.UserId = id;
            await candidateManager.CreateCandidate(candidate);
            return RedirectToAction("index", "Home");
        }

        /// <summary>
        /// 显示编辑界面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetEdit()
        {
            var id= HttpContext.User.Identity.Uid();
            var candidate = await candidateManager.GetCandidate(id);
            return View("Edit",candidate);
        }
        /// <summary>
        /// 更新报考信息
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public async Task<IActionResult> update(Candidate candidate)
        {
            var id = HttpContext.User.Identity.Uid();
            candidate.UserId = id;
            await candidateManager.update(candidate);
            return RedirectToAction("index","Home");
        }
    }
}

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

        public IActionResult Message()
        {
            return View();
        }
    }
}

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
    public class JobController:Controller
    {
        private readonly IJobManager jobManager;
        public JobController(IJobManager jobManager)
        {
            this.jobManager = jobManager;
        }
        /// <summary>
        /// 显示创建岗位界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 保存创建岗位信息
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(Job job)
        {
            var id = HttpContext.User.Identity.Uid();
            job.CreaterId = id;
            await jobManager.CreateAsync(job);
            return RedirectToAction("JobList", "Job");
        }

        /// <summary>
        /// 展示我的查询列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> JobList()
        {
            List<Job> jobs = await jobManager.JobList(HttpContext.User.Identity.Uid());
            return View("jobList",jobs);
        }

        /// <summary>
        /// 显示岗位详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(long id)
        {
            var job = await jobManager.GetDetails(id);
            return View("Details",job);
        }

        /// <summary>
        /// 显示修改界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            var job = await jobManager.GetDetails(id);
            return View("Edit",job);
        }
        
        /// <summary>
        /// 修改岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveEdit(Job job)
        {
            var id = HttpContext.User.Identity.Uid();
            job.CreaterId = id;
            await jobManager.UpdateAsync(job);
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(long id)
        {
            await jobManager.DeleteJob(new Job { Id = id});

            return Json(new ReturnResult ());
        }

        public async Task<IActionResult> AllJob()
        {
            var jobs = await jobManager.QueryAsync();
            return View("AllJob",jobs);
        }
    }
}

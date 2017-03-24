using Microsoft.AspNetCore.Mvc;
using ServantApply.Common.IManagers;
using ServantApply.Common.Models;
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
            DateTime dt = DateTime.Now;
            job.Time = dt;
            job.CreaterId = 1;
            await jobManager.CreateAsync(job);
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// 展示查询列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> JobList()
        {
            long createrId = 1;
            //var jobs =await jobManager.JobList(createrId);
            List<Job> jobs = await jobManager.JobList(createrId);
            return View("jobList",jobs);
        }
        public async Task<IActionResult> Details(long id)
        {
            var job = await jobManager.GetDetails(id);
            return View("Details",job);
        }
    }
}

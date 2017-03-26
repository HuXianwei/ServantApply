﻿using ServantApply.Common.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServantApply.Common.Models;
using ServantApply.Common;
using Microsoft.EntityFrameworkCore;

namespace ServantApply.Core
{
    public class JobManager : IJobManager
    {
        private readonly ApplicationDbContext context;
        public JobManager(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// 增加岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task CreateAsync(Job job)
        {
            DateTime dt = DateTime.Now;
            job.Time = dt;
            context.Job.Add(job);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task DeleteJob(Job job)
        {
            context.Job.Remove(job);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteJob(long id)
        {
            context.Job.Remove(new Job { Id = id});
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// 更新岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Job job)
        {
           context.Job.Update(job);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 查询岗位详情
        /// </summary>
        /// <returns></returns>
        public async Task<Job> GetDetails(long id)
        {
            var job = await context.Job.SingleAsync(c => c.Id == id);
            return job;
        }

        /// <summary>
        /// 查询创建岗位
        /// </summary>
        /// <returns></returns>
        public async Task<List<Job>> JobList(long createrId)
        {
            //var job = await context.Job.ToListAsync();
            //var jobs = context.Job.Where(b=>b.CreaterId== createrId).ToList();
            var jobs = await context.Job.Where(c=> c.CreaterId == createrId).ToListAsync();
            return jobs;
        }
        /// <summary>
        /// 查询全部岗位
        /// </summary>
        /// <returns></returns>
        public async Task<List<Job>> QueryAsync()
        {
            var jobs = await context.Job.ToListAsync();
            return jobs;
        }

    }
}

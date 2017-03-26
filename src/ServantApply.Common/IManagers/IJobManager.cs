using ServantApply.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.IManagers
{
    public interface IJobManager
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        Task CreateAsync(Job job);

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        Task<List<Job>> QueryAsync();
        /// <summary>
        /// 查询创建岗位
        /// </summary>
        /// <returns></returns>
        Task<List<Job>> JobList(long createrId);
        /// <summary>
        /// 查询岗位详情
        /// </summary>
        /// <returns></returns>
        Task<Job> GetDetails(long id);

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        Task DeleteJob(Job job);

        /// <summary>
        /// 更新岗位
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        Task UpdateAsync(Job job);
    }
}

using Microsoft.EntityFrameworkCore;
using ServantApply.Common;
using ServantApply.Common.IManagers;
using ServantApply.Common.Models;
using ServantApply.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Core
{
    public class CandidateManager : ICandidateManager
    {
        private readonly ApplicationDbContext context;
        public CandidateManager(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// 新增报考信息
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public async Task CreateCandidate(Candidate candidate)
        {
            context.Candidate.Add(candidate);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 查询报考信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<Candidate> GetCandidate(long id)
        {
            var candidate = await context.Candidate.SingleOrDefaultAsync(c=>c.Id==id);
            return candidate;
        }
        /// <summary>
        /// 更新报考信息
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public async Task update(Candidate candidate)
        {
            context.Candidate.Update(candidate);
            await context.SaveChangesAsync();
        }
    }
}

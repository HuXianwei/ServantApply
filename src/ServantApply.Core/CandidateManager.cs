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

        public Task CreateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
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
    }
}

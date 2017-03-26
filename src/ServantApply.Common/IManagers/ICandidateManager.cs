using ServantApply.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.IManagers
{
    public interface ICandidateManager
    {
        /// <summary>
        /// 查询报考信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Candidate> GetCandidate(long id);
        /// <summary>
        /// 新增报考信息表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task CreateCandidate(Candidate candidate);
       
    }
}

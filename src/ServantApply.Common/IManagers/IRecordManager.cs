using ServantApply.Common.Models;
using ServantApply.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.IManagers
{
    public interface IRecordManager
    {
        /// <summary>
        ///创建报考记录表
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task Create(Record record);

        /// <summary>
        /// 根据用户ID和岗位ID获取报考记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<Record> GetRecordAsync(long userId, long jobId);

        /// <summary>
        /// 根据状态获取报考记录
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<List<RecordModel>> GetRecordsAsync(int status);

        /// <summary>
        /// 审核报考记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<ReturnResult> CheckRecordAsync(long id, string message, long checkId, int status);

        /// <summary>
        /// 获取某个状态下报名记录数量
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<int> GetRecordCountAsync(int status);

        /// <summary>
        /// 根据用户Id获取报考报考记录
        /// </summary>
        /// <param name="useId"></param>
        /// <returns></returns>
        Task<List<RecordModel>> GetRecord(long useId);

        /// <summary>
        /// 打印准考证
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        Task<CandidateModel> PrintMessage(long recordId);
    }
}

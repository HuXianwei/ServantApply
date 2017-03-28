using ServantApply.Common.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServantApply.Common.Models;
using ServantApply.Common;
using Microsoft.EntityFrameworkCore;
using ServantApply.Common.ViewModels;

namespace ServantApply.Core
{
    public class RecordManager : IRecordManager
    {
        private readonly ApplicationDbContext context;
        public RecordManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 创建报考记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task Create(Record record)
        {
            DateTime time = new DateTime();
            record.Time = time;
            context.Record.Add(record);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 根据用户ID和岗位ID获取报考记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<Record> GetRecordAsync(long userId, long jobId)
        {
            var record = await context.Record.Where(c => (c.UserId == userId && c.JobId == jobId)).FirstOrDefaultAsync();
            return record;
        }

        /// <summary>
        /// 根据状态获取报考记录
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<RecordModel>> GetRecordsAsync(int status)
        {
            //List<RecordModel> records = await context.Record.FromSql(string.Format(@"SELECT r.id AS Id, r.userId AS UserId, r.jobId AS JobId, r.checkId AS CheckId, r.time AS Time, r.`status` AS `Status`, r.checkTime AS CheckTime, r.memo AS Memo, u.`name` AS UserName, j.`name` AS JobName
            //FROM record AS r LEFT JOIN `user` AS u on r.userId = u.id LEFT JOIN job AS j ON r.jobId = j.id WHERE r.`status` = {0}", status)).ToListAsync();
            var records = await context.Record.Where(c => c.Status == status).ToListAsync();
            List<RecordModel> models = new List<RecordModel>();
            if (records == null)
                return models;
            foreach (var item in records)
            {
                RecordModel model = new RecordModel(item);
                model.UserName = (await context.User.SingleOrDefaultAsync(c => c.Id == item.UserId)).Name;
                model.JobName = (await context.Job.SingleOrDefaultAsync(c => c.Id == item.JobId)).Name;
                models.Add(model);
            }
            return models;
        }

        /// <summary>
        /// 审核报考记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<ReturnResult> CheckRecordAsync(long id, string message, long checkId, int status)
        {
            ReturnResult result = new ReturnResult();
            //验证审核信息
            message = message.Trim();
            if (string.IsNullOrEmpty(message))
            {
                result.IsSuccess = false;
                result.Message = "审核信息不能为空！";
                return result;
            }
            //更新审核信息
            var record = await context.Record.SingleOrDefaultAsync(c => c.Id == id);
            record.CheckId = checkId;
            record.Memo = message;
            record.Status = status;
            record.CheckTime = DateTime.Now;
            context.Record.Update(record);
            await context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// 获取某个状态下报名记录数量
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<int> GetRecordCountAsync(int status)
        {
            return await context.Record.Where(c => c.Status == status).CountAsync();
        }

        /// <summary>
        /// 根据用户Id获取报考报考记录
        /// </summary>
        /// <param name="useId"></param>
        /// <returns></returns>
        public async Task<List<RecordModel>> GetRecord(long userId)
        {
            List<Record> list = await context.Record.Where(c => c.UserId == userId).ToListAsync();
            List<RecordModel> records = new List<RecordModel>();
            if (list == null)
                return records;
            foreach (var item in list)
            {
                RecordModel model = new RecordModel(item);
                model.UserName = (await context.User.SingleOrDefaultAsync(c => c.Id == item.UserId)).Name;
                model.JobName = (await context.Job.SingleOrDefaultAsync(c => c.Id == item.JobId)).Name;
                records.Add(model);
            }
            return records;
        }

        /// <summary>
        /// 打印准考证
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task<CandidateModel> PrintMessage(long recordId)
        {
            var record = await context.Record.SingleOrDefaultAsync(c => c.Id == recordId);
            var candidate = await context.Candidate.SingleOrDefaultAsync(a => a.Id == record.UserId);
            var job = await context.Job.SingleOrDefaultAsync(b => b.Id == record.JobId);
            CandidateModel candidateModel = new CandidateModel(candidate);
            candidateModel.JobId = job.Id;
            candidateModel.JobName = job.Name;
            return candidateModel;
        }
    }
}

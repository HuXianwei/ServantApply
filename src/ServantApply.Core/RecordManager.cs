using ServantApply.Common.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServantApply.Common.Models;
using ServantApply.Common;

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
    }
}

using ServantApply.Common.Models;
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
    }
}

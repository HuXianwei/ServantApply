using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using ServantApply.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// 岗位表
        /// </summary>
        public DbSet<Job> Job { get; set; }

        /// <summary>
        /// 报名记录表
        /// </summary>
        public DbSet<Record> Record { get; set; }

        /// <summary>
        /// 考生表
        /// </summary>
        public DbSet<Candidate> Candidate { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}

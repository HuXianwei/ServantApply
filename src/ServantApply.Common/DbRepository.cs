using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common
{
    public class DbRepository<T> : DbContext
    {
        public DbRepository(DbContextOptions<DbRepository<T>> options) : base(options)
        {
        }

        public static DbRepository<T> GenerateContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbRepository<T>>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new DbRepository<T>(optionsBuilder.Options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}

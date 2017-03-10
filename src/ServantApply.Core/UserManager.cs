using Microsoft.EntityFrameworkCore;
using ServantApply.Common;
using ServantApply.Common.IManagers;
using ServantApply.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Core
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext context;
        public UserManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateAsync(User user)
        {
            context.User_users.Add(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteAsync(User user)
        {
            context.User_users.Remove(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> QueryAsync()
        {
            IQueryable<User> query = context.Set<User>();
            var user = context.User_users.Single(b => b.Id == 1);
            var users = await context.User_users.ToListAsync();
            var tmp = "ew";
            var Userss = context.User_users.Where(c => c.Name.Contains(tmp.Trim())).ToList();
            var usersss = context.User_users.FromSql("Select * from user_users where id > 10").ToList();
            //IQueryable<User> query = context.User_users.Take(10);
            //await context.SaveChangesAsync();
            return query.ToList();
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateAsync(User user)
        {
            context.User_users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}

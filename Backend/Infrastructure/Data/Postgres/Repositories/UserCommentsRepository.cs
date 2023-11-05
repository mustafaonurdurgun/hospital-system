using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Repositories
{
    public class UserCommentsRepository : Repository<UserComment, int>, IUserCommentsRepository
    {
        public UserCommentsRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }
        public async Task<IList<UserComment>> GetAllAsync(Expression<Func<UserComment, bool>>? filter = null)
        {
            IQueryable<UserComment> advertQuery = PostgresContext.Set<UserComment>();

            if (filter != null)
            {
                advertQuery = advertQuery.Where(filter);
            }

            var events = await advertQuery
                .Include(r => r.User)
                .Include(r=>r.Comments)
                .Include(r=>r.Comments.Header)
                .Include(r=>r.Comments.Content)                
                .ToListAsync();

            return events;
        }
    }
}

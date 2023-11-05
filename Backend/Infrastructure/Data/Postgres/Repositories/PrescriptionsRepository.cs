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
    public class PrescriptionsRepository : Repository<Prescriptions, int>,IPrescriptionsRepository
    {
        public PrescriptionsRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }
        public async Task<IList<Prescriptions>> GetAllAsync(Expression<Func<Prescriptions, bool>>? filter = null)
        {
            IQueryable<Prescriptions> query = PostgresContext.Set<Prescriptions>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var events = await query.Include(r => r.User).ToListAsync();


            return events;
        }
    }
}

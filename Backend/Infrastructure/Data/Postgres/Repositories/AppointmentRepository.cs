using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Repositories
{
    public class AppointmentRepository : Repository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentRepository(PostgresContext postgresContext)
            : base(postgresContext) { }

        public async Task<IList<Appointment>> GetAllAsync(
            Expression<Func<Appointment, bool>>? filter = null
        )
        {
            IQueryable<Appointment> query = PostgresContext.Set<Appointment>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var events = await query.Include(r => r.User).ToListAsync();

            return events;
        }

        public async Task AddAsync(Appointment entity)
        {
            entity = ConvertDateTimePropertiesToUtc(entity);

            await PostgresContext.Set<Appointment>().AddAsync(entity);
        }

        private Appointment ConvertDateTimePropertiesToUtc(Appointment entity)
        {
            var properties = entity
                .GetType()
                .GetProperties()
                .Where(
                    prop =>
                        prop.PropertyType == typeof(DateTime)
                        || prop.PropertyType == typeof(DateTime?)
                );

            foreach (var property in properties)
            {
                var value = (DateTime?)property.GetValue(entity);
                if (value.HasValue)
                {
                    property.SetValue(entity, value.Value.ToUniversalTime());
                }
            }

            return entity;
        }
    }
}

using Infrastructure.Data.Postgres.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Appointment:Entity<int>
    {

        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public bool IsConfirmed { get; set; }

        public int userID { get; set; }
        public User User { get; set; }


    }
}

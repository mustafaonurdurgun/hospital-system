using Infrastructure.Data.Postgres.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Prescriptions:Entity<int>
    {
        
        public string Medication { get; set; }
        public string Instructions { get; set; }

        public int userID { get; set; }
        public User User { get; set; }
    }
}

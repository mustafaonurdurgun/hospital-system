using Infrastructure.Data.Postgres.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Comments:Entity<int>
    {
        public string Header { get; set; }
        public string Content { get; set; }
        

        public IList<UserComment> UserComments { get; set; }
    }
}

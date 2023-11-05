using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Update
{
    public class UpdatePrescriptionsDTO
    {
        public string Medication { get; set; }
        public string Instructions { get; set; }

        public int userID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class PrescriptionsInfoDTO
    {
        public int Id { get; set; }
        public string Medication { get; set; }
        public string Instructions { get; set; }
        public UserProfileDto User{get;set;}

    }
}

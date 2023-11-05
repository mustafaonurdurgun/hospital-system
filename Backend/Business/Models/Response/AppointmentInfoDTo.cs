using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class AppointmentInfoDTo
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }

        public bool IsConfirmed { get; set; }

        public UserProfileDto User{get;set;}
    }
}

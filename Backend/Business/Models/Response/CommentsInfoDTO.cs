using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class CommentsInfoDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public UserProfileDto User{get;set;}

    }
}

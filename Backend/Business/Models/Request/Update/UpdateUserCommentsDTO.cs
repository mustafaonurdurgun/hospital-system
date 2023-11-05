using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Update
{
    public class UpdateUserCommentsDTO
    {
        public int UserId { get; set; }

        public int CommentId { get; set; }
    }
}

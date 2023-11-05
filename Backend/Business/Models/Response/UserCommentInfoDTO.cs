using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
  public class UserCommentInfoDTO
  {
    public int Id { get; set; }
    public int UserID { get; set; }
    public int CommentID { get; set; }
    public UserProfileDto User { get; set; }
    public CommentsInfoDTO Comments { get; set; }


  }
}

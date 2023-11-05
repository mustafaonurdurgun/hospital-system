import { Comments } from "./comments";
import { User } from "./user.model";

export interface UserComment {
    userCommentID: number;
    userId: number;
    user: User;
    commentId: number;
    comments: Comments;
}
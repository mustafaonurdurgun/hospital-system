import { Entity } from "./entity.model";
import { UserComment } from "./userComment";

export class Comments extends Entity<number> {
    header?: string;
    content?: string;
    userComments?: UserComment[];
}
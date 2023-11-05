import { Entity } from "./entity.model";
import { User } from "./user.model";

export class Prescriptions extends Entity<number> {
    medication?: string;
    instructions?: string;
    userID?: number;
    user?: User;
}
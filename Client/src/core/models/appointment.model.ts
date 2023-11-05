import { Entity } from "./entity.model";
import { User } from "./user.model";

export class Appointment extends Entity<number> {
    appointmentDate?: string;
    reason?: string;
    isConfirmed: boolean=true;
    userID?: number;
    user?: User;
}
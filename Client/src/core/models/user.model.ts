import { Appointment } from "./appointment.model";
import { Entity } from "./entity.model";
import { Prescriptions } from "./prescriptions";
import { UserComment } from "./userComment";

export class User extends Entity<number> {
    email?: string;
    userName?: string;
    firstName?: string;
    lastName?: string;
    age?: number;
    password: string = '';
    userType?: UserType;
    prescriptions?: Prescriptions[];
    appointments?: Appointment[];
    userComments?: UserComment[];
}

export enum UserType {
    Admin,
    Doctor,
    Secretary,
    Patient
}
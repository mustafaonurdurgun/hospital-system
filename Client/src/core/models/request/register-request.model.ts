import { Appointment } from "../appointment.model";
import { Prescriptions } from "../prescriptions";
import { UserComment } from "../userComment";

export interface RegisterRequest {
  Email: string;
  UserName: string;
  FirstName: string;
  LastName: string;
  Age:number;
  Password: string ;
  UserType: UserType.Doctor

}
export enum UserType {
  Admin,
  Doctor,
  Secretary,
  Patient
}


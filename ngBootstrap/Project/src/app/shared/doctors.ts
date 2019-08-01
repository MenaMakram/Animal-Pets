import { User } from './user';
import { DoctorDetails } from './DoctorDetails';
export class Doctors {
    public  ID:number
    public  HasClinic:boolean
    public user:User
    public clinic:DoctorDetails[]
}
export class Users {
  UserName: string;
  Password: string;
  Email: string;
  FirstName: string;
  LastName: string;
  ID: string;
  Address: string;
  Phone: string;
  Photo: string ;
    //Doctor Dto
  HasClinic: boolean;
  DoctorClinics: string[] = new Array() ;
    //Home Pets
    Description: string;
   AvailablePlace: number;
     NumberOfRooms: number;

     PriceForNight: number;
    //tranier
    JobTitle: string;
    Overview: string;
    Courses: string[];
    TrainePlace: string;
    PricePerHour: number;
    //type user
    TypeRegistration: string;
}

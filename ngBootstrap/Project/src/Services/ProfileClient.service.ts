import { HomePetsPhoto } from './HomePetsPhoto';
import { AnimalPhoto } from './AnimalPhoto';
import { Animals } from './Animals';
import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { User } from './User';
import { Trainer } from './Trainer';
import { HomePets } from './HomePets';
import { Clinic } from './Clinic';
@Injectable({
  providedIn: 'root'
})
export class ProfileClientService {

constructor(protected http: HttpClient) { }
  getClient(id: string) {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return  this.http.get(environment.API_URL + 'GetClientProfile/' + id);
  }
  getDoctor(id: string) {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return  this.http.get(environment.API_URL + 'GetDoctorProfile/' + id);
  }
  getTrainer(id: string) {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return  this.http.get(environment.API_URL + 'GetTrainerProfile/' + id);
  }
  getHomePets(id: string) {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return  this.http.get(environment.API_URL + 'GetHomePetsProfile/' + id);
  }
  getUser(id: string) {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return  this.http.get(environment.API_URL + 'GetUserProfile/' + id);
  }
  editUser(user: User)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.put(environment.API_URL + 'EditUserProfile/', user);
  }
  editTrainer(trainer: Trainer)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.put(environment.API_URL + 'EditTrainerProfile/', trainer);
  }
  edithomePets(homePets: HomePets)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.put(environment.API_URL + 'EditHomePetsProfile/', homePets);
  }
  editClinic(clinic: Clinic)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.put(environment.API_URL + 'EditClinic/', clinic);
  }
  AddClinic(userID: string, clinic: Clinic)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.post(environment.API_URL + 'AddClinic/'+userID, clinic);
  }
  DeleteClinic(userID: string, clinicID: number)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.put(environment.API_URL + 'DeleteClinic/' + userID,clinicID);
  }
  AddAnimal(userID: string, animal: Animals)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.post(environment.API_URL + 'InsertAnimal/' + userID, animal);
  }
  editAnimal(Id: number, animal: Animals)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.put(environment.API_URL + 'UpdateAnimal/' + Id, animal);
  }
  DeleteAnimals(userID: number)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.delete(environment.API_URL + 'DeleteAnimal/' + userID);
  }
  getCategory()
  {
    return  this.http.get(environment.API_URL + 'GetGategory/');
  }
  DeletePhoto(userID: number)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.delete(environment.API_URL + 'DeletePhoto/' + userID);
  }
  AddPhoto(userID: number, animalPhoto: AnimalPhoto[])
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.post(environment.API_URL + 'AddPhoto/' + userID, animalPhoto);
  }
  DeleteHomePhoto(userID: number)
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.delete(environment.API_URL + 'DeleteHomePetsPhoto/' + userID);
  }
  AddHomePhoto(userID: string, homePetsPhoto: HomePetsPhoto[])
  {
    const reqHeader = new HttpHeaders({'No-Auth': 'True'});
    return this.http.post(environment.API_URL + 'AddHomePetsPhoto/' + userID, homePetsPhoto);
  }
  UserProfilePhoto(userID: string, user: User)
  {
    return this.http.post(environment.API_URL + 'UserProfilePhoto/' + userID, user);
  }
}

import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Trainers } from './trainers';

@Injectable({
  providedIn: 'root'
})
export class TrainersService {
  readonly rootUrl = 'http://localhost:61646';

  constructor(private http: HttpClient) { }
  getAllTrainers(): Observable<Trainers[]> {
    return this.http
      .get<Trainers[]> (this.rootUrl + '/api/Trainers');
  }
  getTrainer(price:number,Course:string,address:string): Observable<Trainers[]> {
    return this.http
      .get<Trainers[]> (this.rootUrl + '/api/TrainerSearch?price='+price+'&&Course='+Course+'&&address='+address);
  }
}

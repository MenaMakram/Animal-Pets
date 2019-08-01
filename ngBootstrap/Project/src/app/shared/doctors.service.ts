import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Doctors } from './doctors';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {
  readonly rootUrl = 'http://localhost:61646';

  constructor(private http: HttpClient) { }
  getAllDoctors(): Observable<Doctors[]> {
    return this.http
      .get<Doctors[]> (this.rootUrl + '/api/Doctor');
  }
  getDoctor(Name:string,address:string): Observable<Doctors[]> {
    return this.http
    .get<Doctors[]> (this.rootUrl + '/api/DoctorSearch?Name='+Name+'&&address='+address);
  }
}

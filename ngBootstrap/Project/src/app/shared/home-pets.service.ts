import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HomePets } from './home-pets';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomePetsService {
  readonly rootUrl = 'http://localhost:61646';

  constructor(private http: HttpClient) { }
  getAllHomePets(): Observable<HomePets[]> {
    return this.http
      .get<HomePets[]> (this.rootUrl + '/api/HomePets');
  }
  getHomePets(price:number,avaliable:number,address:string): Observable<HomePets[]> {
    return this.http
      .get<HomePets[]> (this.rootUrl + '/api/HomePetsSearch?price='+price+'&&avaliable='+avaliable+'&&address='+address);
  }
}

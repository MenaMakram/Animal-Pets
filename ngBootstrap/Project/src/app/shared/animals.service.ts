import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Animals } from './animals';
@Injectable({
  providedIn: 'root'
})
export class AnimalsService {
  readonly rootUrl = 'http://localhost:61646';

  constructor(private http: HttpClient) { }
  getAllDoctors(): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/Animal');
  }
  SearchGetAll( age:number,  MarriedCount:number,  address:string, category:string, type:string,  gander:string): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGetAll?age='+age+'&&MarriedCount='+MarriedCount+'&&address='+address+'&&category='+category+'&&type='+type+'&&gander='+gander);
  }


  SearchGetAge( age:number): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGetAge?age='+age);
  }


  SearchGetMarr(   MarriedCount:number): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGetMarr?MarriedCount='+MarriedCount);
  }


  SearchGetaddress(  address:string): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGetaddress?address='+address);
  }



  SearchGetcategory( category:string): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGetcategory?category='+category);
  }


  SearchGettype(type:string): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGettype?type='+type);
  }


  SearchGetgander(  gander:string): Observable<Animals[]> {
    return this.http
      .get<Animals[]> (this.rootUrl + '/api/SearchGetgander?gander='+gander);
  }

}

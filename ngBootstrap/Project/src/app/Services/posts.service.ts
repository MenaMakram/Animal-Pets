import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import { from, Observable } from 'rxjs';
import { Post } from '../Dto/post';
import { GetPosts } from '../Dto/get-posts';
import {WriteComment} from '../Dto/write-comment';
import { UpdatePost } from '../Dto/updatePost';
import { Likes } from '../Dto/Likes';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
   rootUrl:string = 'http://localhost:61646/api/';
   url: string = './src/assets';

  constructor(private http:HttpClient) { }
  getAllPosts():Observable<Array<GetPosts[]>>{
    return this.http.get<Array<GetPosts[]>>(this.rootUrl+'Posts');
  }
  getMyPosts(name:string):Observable<Array<GetPosts[]>>{
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.get<Array<GetPosts[]>>(this.rootUrl+'Posts/'+name,{headers:reqHeader});
  }
  addPost(post:Post): Observable<Post>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    return this.http.post<Post>((this.rootUrl + 'Posts'), post, httpOptions);
  }
  updatePost(post: UpdatePost): Observable<UpdatePost> {
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    return this.http.post<UpdatePost>((this.rootUrl + 'Posts/Update'), post, httpOptions);
  }
  getAllCOmments(): Observable<Array<WriteComment[]>> {
    return this.http.get<Array<WriteComment[]>>((this.rootUrl + 'getcomm'));
  }
  addComment(comm:WriteComment): Observable<WriteComment>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    return this.http.post<WriteComment>((this.rootUrl+'Posts/comm'),comm,httpOptions);
  }
  // getLikes(post: number):Observable<number>{
  //   const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
  //   return this.http.post<number>((this.rootUrl+'Posts/like/'),post,httpOptions);
  // }
  RLikes(post: number): Observable<number> {
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    return this.http.post<number>((this.rootUrl + 'Posts/Rlike/'), post, httpOptions);
  }
  getPostById(Id: number): Observable<GetPosts> {
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.get<GetPosts>((this.rootUrl + 'getPost/' + Id), {headers: reqHeader});
  }
  deletePost(Id: number) : Observable<number>{
    console.log(Id);
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};

    return this.http.post<number>((this.rootUrl + 'Posts/Delete'), Id, httpOptions);
  }
  getLikes(post: Likes): Observable<Likes>{
    const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    return this.http.post<Likes>((this.rootUrl+'Posts/like'),post,httpOptions);
  }
}

import { Component, OnInit, AfterContentInit, ElementRef, Input } from '@angular/core';
import { PostsService } from '../Services/posts.service';
import { Post } from '../Dto/post';
import { Router } from '@angular/router';
import { GetPosts } from '../Dto/get-posts';
import { WriteComment } from '../Dto/write-comment';
import { ViewChild } from '@angular/core';
import { ImageUploadService } from '../Services/ImageUpload.service';
import { UserService } from '../shared/user.service';
import { User } from 'src/Services/User';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { Likes } from '../Dto/Likes';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/skipWhile';
import 'rxjs/add/operator/scan';
import 'rxjs/add/operator/takeWhile';
import 'rxjs/add/operator/throttleTime';
import 'rxjs/add/observable/interval';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/switchMap';

import { Observable } from 'rxjs';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  //@ViewChild('myInput')
  myInputVariable: ElementRef;
  post: Post = {
    Description: '', UserName: '', PostDateTime: new Date(Date.now())
    , postPhotos: []
  };
  writeComm: WriteComment = { ID: null, Description: '', CommentDateTime: new Date(Date.now()), PostID: null, UserId: '', UserName: '', UserPhoto: '' };
  //getPots: Array<GetPosts[]>;
  @Input() getPots$: Observable<Array<GetPosts[]>>;
  urls = [] = new Array();
  arr: number[] = [];
  public show = false;
  filesss = FileList;
  comment = '';
  Addres = '';
  user: User = new User();
  users: User = new User();
  userLike: Likes = {postId: null, userName: ''};
  constructor(private service: PostsService,
              private router: Router,
              private img: ImageUploadService,
              private userservice: UserService,
              private profile: ProfileClientService,
              ) {
  }
  ngOnInit() {
    this.userservice.getUserClaims().subscribe(data1 => {
      this.profile.getUser(data1.ID).subscribe((data2: any) => {

        this.users = data2;
        this.Addres = 'https://www.google.com/maps/embed/v1/place?key=AIzaSyDsdf8mocPYJB3GfPWL62RMnp_c-19kMXY&q=' + this.users.Address;
      });
      });
    this.getPots$ = Observable.interval(5000).distinctUntilChanged()
      .startWith(0).switchMap(() => this.service.getAllPosts());

  }
  onSelectFile(event) {
    let files = FileList;
    if (event.target.files && event.target.files[0]) {
      files = event.target.files;
      const filesAmount = event.target.files.length;
      for (let i = 0; i < filesAmount; i++) {
        const reader = new FileReader();
        reader.onload = (event: any) => { this.urls.push(event.target.result); };
        reader.readAsDataURL(files[i]);
      }
      for (let i = 0; i < files.length; ++i) { this.post.postPhotos[i] = (files[i].name); }
    }
    this.filesss = files;
  }
  Share() {

    this.userservice.getUserClaims().subscribe((data: any) => {
      this.post.UserName = data.UserName;
      if (this.post.Description === '') {
        this.reset();
        this.urls = null;
      } else {
        for (let i = 0; i < this.filesss.length; i++) {
          this.img.postFile(this.filesss[i]).subscribe(data => { });
        }
        this.service.addPost(this.post).subscribe((data) => { this.ngOnInit(); });
        this.post.Description = '';
        this.reset();
        this.urls = null;
      }
    });

  }
  toggle(n: number) {

    if (this.arr.indexOf(n) !== -1) {
      this.show = false;
      this.arr.splice(this.arr.indexOf(n), 1);
    } else {
      this.show = true;
      this.arr.push(n);
    }
  }
  keyDownFunction(event, postId, value) {

    if (event.keyCode === 13 && value.value != null) {
      this.writeComm.PostID = postId;
      this.writeComm.Description = value.value;
      console.log('' + postId);
      this.userservice.getUserClaims().subscribe((data: any) => {
        console.log(JSON.stringify(data));
        this.writeComm.UserId = data.ID;
        this.post.UserName = data.UserName;
        this.service.addComment(this.writeComm).subscribe((data => this.ngOnInit()));
        value.value = '';
      });
    } else { }

  }
  like(postID: number) {
    this.userLike.postId = postID;
    this.userservice.getUserClaims().subscribe(data => {
      this.userLike.userName = data.UserName;
      this.service.getLikes(this.userLike).subscribe(data => { this.ngOnInit(); });
    });
}
  // like(postID: number) {
  //   if (this.arr.indexOf(postID) != -1) {
  //     this.service.RLikes(postID).subscribe(data => this.ngOnInit());
  //     this.arr.splice(this.arr.indexOf(postID), 1);
  //   }
  //   else {
  //     this.service.getLikes(postID).subscribe(data => { this.ngOnInit() })
  //     this.arr.push(postID);
  //   }
  // }
  reset() {
    this.myInputVariable.nativeElement.value = '';
    this.urls = null;
  }
}

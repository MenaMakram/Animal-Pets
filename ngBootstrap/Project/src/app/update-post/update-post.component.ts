import { Component, OnInit, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostsService } from '../Services/posts.service';
import { GetPosts } from '../Dto/get-posts';
import { Post } from '../Dto/post';
import { ViewChild } from '@angular/core';
import { ImageUploadService } from '../Services/ImageUpload.service';
import { UpdatePost } from '../Dto/updatePost';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-update-post',
  templateUrl: './update-post.component.html',
  styleUrls: ['./update-post.component.css']
})
export class UpdatePostComponent implements OnInit {
  //@ViewChild('myInput')
  myInputVariable: ElementRef;
  postId: number;
  getPots: GetPosts;
  filesss = FileList;
  post: UpdatePost = {
    ID: null, Description: '', UserName: '', PostDateTime: new Date(Date.now())
    , postPhotos: []
  };
  urls = [];
  constructor(private router: ActivatedRoute,
              private service: PostsService,
              private img: ImageUploadService,
              private userservice: UserService,
              private routers: Router) { }

  ngOnInit() {
    let id = parseInt(this.router.snapshot.paramMap.get('id'));
    this.postId = id;
    this.service.getPostById(this.postId).subscribe(data => { this.getPots = data; });
  }
  onSelectFile(event) {
    if (event.target.files[0] != null) {
      this.getPots.postPhotos = null;
      let files = FileList;
      if (event.target.files && event.target.files[0]) {
        files = event.target.files;
        var filesAmount = event.target.files.length;
        for (let i = 0; i < filesAmount; i++) {
          var reader = new FileReader();
          reader.onload = (event: any) => { this.urls.push(event.target.result); };
          reader.readAsDataURL(files[i]);
        }
        for (let i = 0; i < files.length; ++i) { this.post.postPhotos[i] = (files[i].name); }
      }
      this.filesss = files;
    }
  }
  Update() {
    this.post.ID = this.postId;
    this.userservice.getUserClaims().subscribe(data => {
      this.post.UserName = data.Username;
    });
    if (this.post.Description === '') {
      for (let i = 0; i < this.filesss.length; i++) {
        this.img.postFile(this.filesss[i]).subscribe(data => {
          console.log(this.filesss[i]);
        });
      }
      this.post.Description = this.getPots.Description;
      this.service.updatePost(this.post).subscribe((data) => { this.ngOnInit(); });
      this.reset();
      this.urls = null;
    }
    else {
      // for (let i = 0; i < this.filesss.length; i++) {
      //   this.img.postFile(this.filesss[i]).subscribe(data => {
      //     console.log(this.filesss[i]);
      //   });
      // }
      if (this.post.postPhotos.length > 0) {
        for (let i = 0; i < this.filesss.length; i++) {

          this.img.postFile(this.filesss[i]).subscribe();
        }
      }
      else {
        this.getPots.postPhotos.forEach((element: any) => {

          this.post.postPhotos.push(element);
        });
        // for (let index = 0; index < this.getPots.postPhotos.length; index++) {
        //   console.log(this.getPots.postPhotos[index]);
        // }
      }
      this.service.updatePost(this.post).subscribe((data) => { this.ngOnInit(); });
      //this.post.Description = '';
      this.reset();
      this.urls = null;

    }
  }
  reset() {

    this.routers.navigate(['/MyPostComponent']);
    this.urls = null;
    this.getPots=null;
    this.post=null;

    this.myInputVariable.nativeElement.value = "";
  }
}

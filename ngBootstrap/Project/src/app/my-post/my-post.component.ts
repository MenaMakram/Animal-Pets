import { Component, OnInit} from '@angular/core';
import { PostsService } from '../Services/posts.service';
import { Router } from '@angular/router';
import { GetPosts } from '../Dto/get-posts';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { UserService } from '../shared/user.service';
import { WriteComment } from '../Dto/write-comment';
import { Post } from '../Dto/post';


@Component({
  selector: 'app-my-post',
  templateUrl: './my-post.component.html',
  styleUrls: ['./my-post.component.css']
})
export class MyPostComponent implements OnInit {
  getPots: Array<GetPosts[]>;
  username: string;
  post: Post = {
    Description: "", UserName: "", PostDateTime: new Date(Date.now())
    , postPhotos: []};
  writeComm: WriteComment = { ID: null, Description: "", CommentDateTime: new Date(Date.now()), PostID: null, UserId: "",UserName:'',UserPhoto:'' }

  constructor(private service: PostsService, private router: Router,private userservice: UserService) {}

  ngOnInit() {
    this.userservice.getUserClaims().subscribe(data1 => {
      this.username = data1.UserName;
      this.service.getMyPosts(this.username).subscribe((data: Array<GetPosts[]>) => {this.getPots = data; });
    });
  }
  Select(Post)
  {
    this.router.navigate(['/UpdatePostComponent',Post.ID]);
  }
  del(id: number)
  {
    this.service.deletePost(id).subscribe((data) => { this.ngOnInit() });
  }
  keyDownFunction(event, postId, value) {
    console.log('Enter 1'+event.keyCode);
    if (event.keyCode === 13 && value != null) {
      console.log('Enter 2'+postId);
      this.writeComm.PostID = postId;
      this.writeComm.Description = value;
      console.log(""+ postId);
      this.userservice.getUserClaims().subscribe((data: any)=>{
        console.log(JSON.stringify(data));
        this.writeComm.UserId = data.ID;
        this.post.UserName = data.UserName;
        value='';
        this.service.addComment(this.writeComm).subscribe((data => this.ngOnInit()));
      });
    }
    else { }

  }
}

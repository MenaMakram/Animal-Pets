import { UserService } from './../shared/user.service';
import { ProfileClientService } from './../../Services/ProfileClient.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/Services/User';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ImageUploadService } from 'src/Services/ImageUpload.service';
@Component({
  selector: 'app-Profile',
  templateUrl: './Profile.component.html',
  styleUrls: ['./Profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: User = new User();
  Id = '';
  Addres = '';
  isopen: boolean = false;
  fileToUpload: File[] = [];
  constructor(protected profileClientService: ProfileClientService,
              protected router: Router,
              protected route: ActivatedRoute,
              private modalService: NgbModal,
              protected imageUpload: ImageUploadService,
              private userservice: UserService
              ) {
                this.ngOnInit();
               }
  // Id = '89414948-052c-4840-af89-566917b02957';
  ngOnInit() {

    this.route.queryParams.subscribe(params => {
    this.Id = params.Id;
    this.profileClientService.getUser(this.Id).subscribe((data: User) => {

      this.userservice.getUserClaims().subscribe(data1 => {

        if (data1.ID === this.Id) {
          this.isopen = true;
        }
      });
      this.user = data;
      this.Addres = 'https://www.google.com/maps/embed/v1/place?key=AIzaSyDsdf8mocPYJB3GfPWL62RMnp_c-19kMXY&q=' + this.user.Address;

    }, error => {
      console.log('error' + error.message);
    });
  });
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.profileClientService.editUser(this.user).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();
        }
      });
      //this.Edit(result);
    }, (reason) => {
    });
  }
  handleFileInput(file: FileList) {
    console.log(file);
    for (let i = 0; i < file.length; i++) {
      this.fileToUpload.push(file.item(i));
    }
  }
  open3(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.user.Photo = null;
      this.user.Photo = this.fileToUpload[0].name;

      this.imageUpload.postFile(this.fileToUpload).subscribe((da) => {
        console.log("image success");

        this.profileClientService.UserProfilePhoto(this.Id, this.user).subscribe(data => {
          console.log("phoyo success");

          if (data === 'Successed') {
            this.ngOnInit();
            this.fileToUpload = [];

          }
        });
      })
    }, (reason) => {
    });
  }

}

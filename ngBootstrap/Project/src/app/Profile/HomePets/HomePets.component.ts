import { HomePetsPhoto } from './../../../Services/HomePetsPhoto';
import { Component, OnInit } from '@angular/core';
import { HomePets } from 'src/Services/HomePets';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { ImageUploadService } from 'src/Services/ImageUpload.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-HomePets',
  templateUrl: './HomePets.component.html',
  styleUrls: ['./HomePets.component.css'],
  providers: [NgbCarouselConfig]
})
export class HomePetsComponent implements OnInit {

  title = 'Profile';
  ID: string;
  homePets: HomePets = new HomePets();
  fileToUpload: File[] = [];
  isopen: boolean = false;
  constructor(config: NgbModalConfig,
              private modalService: NgbModal,
              protected route: ActivatedRoute,
              protected homePetsService: ProfileClientService,
              protected router: Router,
              private imageService: ImageUploadService,
              private userservice: UserService) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.ID = params['Id'];
      this.homePetsService.getHomePets(this.ID).subscribe((data: HomePets) => {
        this.userservice.getUserClaims().subscribe(data1 => {
          if (data1.ID === this.ID) {
            this.isopen = true;
          }
        });
        this.homePets = data;
      });
    });
  }
  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.homePetsService.edithomePets(this.homePets).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();
        }
      });
      //this.Edit(result);
    }, (reason) => {
    });
  }
  deletePhoto(Id: number) {
    this.homePetsService.DeleteHomePhoto(Id).subscribe(data => {
      if (data === 'Successed') {
        this.ngOnInit();
      }
    });
  }
  handleFileInput(file: FileList) {
    console.log(file);
    for (let i = 0; i < file.length; i++) {
      this.fileToUpload.push(file.item(i));
    }
  }
  open3(content, item: HomePets) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.homePets.photos = [];
      for (let index = 0; index < this.fileToUpload.length; index++) {
        const element = this.fileToUpload[index];
        let add = new HomePetsPhoto();
        add.Photo = element.name;
        add.ID = 0;
        this.homePets.photos.push(add);
      }
      this.imageService.postFile(this.fileToUpload).subscribe((da) => {
        console.log("image success");

        this.homePetsService.AddHomePhoto(this.ID, this.homePets.photos).subscribe(data => {
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

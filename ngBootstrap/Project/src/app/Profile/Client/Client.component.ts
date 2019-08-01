import { Category } from './../../../Services/Category';
import { Animals } from './../../../Services/Animals';
import { Clients } from './../../../Services/Clients';
import { Component, OnInit } from '@angular/core';
import { Clinic } from 'src/Services/Clinic';
import { NgbModalConfig, NgbModal, NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { Doctor } from 'src/Services/Doctor';
import { Router, ActivatedRoute } from '@angular/router';
import { ImageUploadService } from 'src/Services/ImageUpload.service';
import { AnimalPhoto } from 'src/Services/AnimalPhoto';
import { UserService } from 'src/app/shared/user.service';


@Component({
  selector: 'app-Client',
  templateUrl: './Client.component.html',
  styleUrls: ['./Client.component.css'],
  providers: [NgbCarouselConfig]
})
export class ClientComponent implements OnInit {

  title = 'Profile';
  ID: string;
  imageUrl: string = "/assets/img/default-image.png";
  Image: any;
  client: Clients = new Clients();
  animals: Animals = new Animals();
  catList: Category [] = new Array();
  fileToUpload: File[] = [];
  isopen: boolean = false;
  constructor(private modalService: NgbModal,
              protected route: ActivatedRoute,
              protected router: Router,
              protected clientService: ProfileClientService,
              protected config: NgbModalConfig,
              private imageService: ImageUploadService,
              private userservice: UserService) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }
  ngOnInit() {


   this.clientService.getCategory().subscribe((data: Category[]) => {
     this.catList = data;
  });
   this.route.queryParams.subscribe(params=>{
     this.ID = params['Id'];
     this.clientService.getClient(this.ID).subscribe((data: Clients) => {
      this.userservice.getUserClaims().subscribe(data1 => {
        console.log(""+JSON.stringify(data1));
        if (data1.ID === this.ID) {
          this.isopen = true;
        }
      });
       this.client = data;
      });
    });
  }
  handleFileInput(file: FileList) {
    console.log(file);
    for (let i = 0; i < file.length; i++) {
      this.fileToUpload.push(file.item(i));
    }
  }
  open(content , item: Animals, Id: number) {
    this.animals = item;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.clientService.editAnimal(Id, item).subscribe(data => {
        if (data === 'Successed') {
          console.log(data);
          this.ngOnInit();
        }
      });
      //this.Edit(result);
    }, (reason) => {
    });
  }
  open1(content) {
    this.animals = new Animals();
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.animals.animalPhoto = [];
      for (let index = 0; index < this.fileToUpload.length; index++) {
        const element = this.fileToUpload[index];
        let add = new AnimalPhoto();
        add.Image = element.name;
        add.ID = 0;
        this.animals.animalPhoto.push(add);
      }
      this.imageService.postFile(this.fileToUpload).subscribe((da)=>{
        this.clientService.AddAnimal(this.ID, this.animals).subscribe(data => {
          if (data === 'Successed') {
            this.ngOnInit();
            this.animals.animalPhoto = [];
            this.fileToUpload = [];
          }
        });
      });
    }, (reason) => {
      console.log(reason);
    });
  }
  open2(content,item: Animals) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.clientService.DeleteAnimals(item.ID).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();

        }
      });
    }, (reason) => {
    });
  }
  open3(content,item: Animals) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.animals.animalPhoto = [];
      for (let index = 0; index < this.fileToUpload.length; index++) {
        const element = this.fileToUpload[index];
        let add = new AnimalPhoto();
        add.Image = element.name;
        add.ID = 0;
        this.animals.animalPhoto.push(add);
      }
      this.imageService.postFile(this.fileToUpload).subscribe((da)=>{
      this.clientService.AddPhoto(item.ID,this.animals.animalPhoto).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();
          this.animals.animalPhoto = [];
          this.fileToUpload = [];
        }
      });
    })}, (reason) => {
    });
  }
  deletePhoto(Id: number)
  {
    this.clientService.DeletePhoto(Id).subscribe(data => {
      if (data === 'Successed')
      {
        this.ngOnInit();
      }
    });
  }

}

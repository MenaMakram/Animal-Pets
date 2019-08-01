import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/Services/Doctor';
import { NgbModalConfig, NgbModal, NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { Clinic } from 'src/Services/Clinic';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-Doctor',
  templateUrl: './Doctor.component.html',
  styleUrls: ['./Doctor.component.css'],
  providers: [NgbCarouselConfig]
})
export class DoctorComponent implements OnInit {

  title = 'Profile';
  ID: string;
  doctor: Doctor = new Doctor();
  clinic: Clinic = new Clinic();
  Week: string[] = ['Saturday', 'Sunday', 'Monday', 'Tuesday', 'Wensday', 'Thursday', 'Friday'];
  isopen: boolean = false;
  constructor(private modalService: NgbModal,
              protected route: ActivatedRoute,
              protected router: Router,
              protected clientService: ProfileClientService,
              protected config: NgbModalConfig,
              protected userservice: UserService) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }
  ngOnInit() {
   this.route.queryParams.subscribe(params=>{
     this.ID = params['Id'];
     this.clientService.getDoctor(this.ID).subscribe((data: Doctor) => {
      this.userservice.getUserClaims().subscribe(data1 => {
        if (data1.ID === this.ID) {
          this.isopen = true;
        }
      });
       this.doctor = data;
      });
    });
  }
  open(content , item: Clinic) {
    this.clinic = item;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.clientService.editClinic(item).subscribe(data => {
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
    this.clinic = new Clinic();
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.clientService.AddClinic(this.ID, this.clinic).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();

        }
      });
      //this.Edit(result);
    }, (reason) => {
    });
  }
  open2(content,item: Clinic) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.clientService.DeleteClinic(this.ID, item.ID).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();

        }
      });
      //this.Edit(result);
    }, (reason) => {
    });
  }
}

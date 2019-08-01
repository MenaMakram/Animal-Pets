import { Component, OnInit } from '@angular/core';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { Trainer } from 'src/Services/Trainer';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-Trainer',
  templateUrl: './Trainer.component.html',
  styleUrls: ['./Trainer.component.css']
})
export class TrainerComponent implements OnInit {
  title = 'Profile';
  trainer: Trainer = new Trainer();
  ID: string;
  isopen: boolean = false;
  constructor(config: NgbModalConfig,
              private modalService: NgbModal,
              protected route: ActivatedRoute,
              protected router: Router,
              protected clientService: ProfileClientService,
              protected userservice: UserService) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }
  ngOnInit() {
   this.route.queryParams.subscribe(params=>{
     this.ID = params['Id'];
     this.clientService.getTrainer(this.ID).subscribe((data: Trainer) => {
      this.userservice.getUserClaims().subscribe(data1 => {
        if (data1.ID === this.ID) {
          this.isopen = true;
        }
      });
        this.trainer = data;
      });
    });
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.clientService.editTrainer(this.trainer).subscribe(data => {
        if (data === 'Successed') {
          this.ngOnInit();
        }
      });
      //this.Edit(result);
    }, (reason) => {
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { TrainersService } from 'src/app/shared/trainers.service';
import { Trainers } from 'src/app/shared/trainers';
// import { TrainersService } from '../shared/trainers.service';
// import { Trainers } from '../shared/trainers';

@Component({
  selector: 'app-trainers',
  templateUrl: './trainers.component.html',
  styleUrls: ['./trainers.component.css']
})
export class TrainersComponent implements OnInit {

  constructor(private Trainer: TrainersService) { }
  TrainersAll: Trainers[];
  price: number;
  show: boolean = false;
  address: string = "null";
  Course: string = "null";
  ngOnInit() {
    this.Trainer.getAllTrainers().subscribe((data) => {
      this.TrainersAll = data;
      console.log(this.TrainersAll[0].user.LastName);

    },
      (err) => {
        console.log(err);
      });
  }
  Search(form) {
    console.log(this.price);
    if (!form.value.price) {
      console.log("sss")
      this.price = null;
    }
    if (form.value.price != '') {
      this.price = form.value.price
    }
    if (form.value.address != '') {
      this.address = form.value.address
    }
    if (form.value.Course != '') {
      this.Course = form.value.Course
    }
    this.Trainer.getTrainer(this.price, this.Course, this.address).subscribe((data) => {
      this.TrainersAll = data;

      if (this.TrainersAll.length == 0) {
        this.show = true;
      } else { this.show = false }
      this.price = null;
      this.address = "null";
      this.Course = "null";
    },
      (err) => {
        console.log(err);
      });

  }

}

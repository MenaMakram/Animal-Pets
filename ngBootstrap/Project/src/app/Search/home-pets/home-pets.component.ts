import { Component, OnInit } from '@angular/core';
import { HomePetsService } from 'src/app/shared/home-pets.service';
import { HomePets } from 'src/app/shared/home-pets';
// import { HomePetsService } from '../shared/home-pets.service';
// import { HomePets } from '../shared/home-pets';

@Component({
  selector: 'app-home-pets',
  templateUrl: './home-pets.component.html',
  styleUrls: ['./home-pets.component.css']
})
export class HomePetsComponent implements OnInit {

  constructor(private HomePets: HomePetsService) { }
  HomeAll: HomePets[];
  price: number;
  show: boolean = false;
  address: string = "null";
  avaliable: number = null;
  ngOnInit() {
    this.HomePets.getAllHomePets().subscribe((data) => {
      this.HomeAll = data;


    },
      (err) => {
        console.log(err);
      });
  }
  Search(form) {
    console.log(this.price);
    if (!form.value.price) {
      this.price = null;
    }
    if (form.value.price != '') {
      this.price = form.value.price
    }
    if (form.value.address != '') {
      this.address = form.value.address
    }
    if (form.value.avaliable != '') {
      this.avaliable = form.value.avaliable
    }
    this.HomePets.getHomePets(this.price, this.avaliable, this.address).subscribe((data) => {
      this.HomeAll = data;

      if (this.HomeAll.length == 0) {
        this.show = true;
      } else { this.show = false }
      this.price = null;
      this.address = "null";
      this.avaliable = null;
    },
      (err) => {
        console.log(err);
      });

  }

}

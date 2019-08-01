import { Component, OnInit } from '@angular/core';
import { DoctorsService } from 'src/app/shared/doctors.service';
import { Doctors } from 'src/app/shared/doctors';


@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  constructor(private Doctors: DoctorsService) { }
  DoctorsAll: Doctors[];
  show: boolean = false;
  address: string = 'null';
  Name: string = 'null';
  ngOnInit() {
    this.Doctors.getAllDoctors().subscribe((data) => {
      this.DoctorsAll = data;
      console.log( this.DoctorsAll[0].clinic[1].ClinicAddress);

    },
    (err) => {
      console.log(err);
    });
  }
  Search(form){

    if(form.value.Name != '')
    {
    this.Name = form.value.Name
    }
    if(form.value.address != '')
    {
    this.address = form.value.address
    }
    this.Doctors.getDoctor(this.Name,this.address).subscribe((data) => {
      this.DoctorsAll = data;
      console.log(data);
      console.log(this.DoctorsAll);

      if (this.DoctorsAll === null)
      {
        this.show = true;
        this.DoctorsAll=[];
      } else {this.show = false}
      this.address = "null";
      this.Name = "null";
    },
      (err) => {
        console.log(err);
      });

}

}

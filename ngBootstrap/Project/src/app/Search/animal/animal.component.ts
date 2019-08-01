import { Component, OnInit } from '@angular/core';
import { AnimalsService } from 'src/app/shared/animals.service';
import { Animals } from 'src/app/shared/animals';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { Category } from 'src/Services/Category';


@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})
export class AnimalComponent implements OnInit {

  constructor(private Animal: AnimalsService,private getprofile:ProfileClientService) { }
  AnimalsAll: Animals[] = [];
  gander: string[] = ['Male','Female'];
  category: Category[] = [];
  show: boolean = false;
  ngOnInit() {
    this.Animal.getAllDoctors().subscribe((data) => {
      this.AnimalsAll = data;
      console.log( this.AnimalsAll[0]);

    },
    (err) => {
      console.log(err);
    });
    this.getprofile.getCategory().subscribe((data: any) => {
      this.category = data;
    });

  }
  Search(form){
    if(form.value.MarriedCount&&form.value.Type&&form.value.address&&form.value.age&&form.value.category&&form.value.gander)
{
  this.Animal.SearchGetAll( form.value.age,  form.value.MarriedCount,  form.value.address, form.value.category, form.value.Type,  form.value.gander).subscribe((data) => {
    this.AnimalsAll=data;
    console.log( this.AnimalsAll[0]);

  },
  (err) => {
    console.log(err);
  });
}
  else if(form.value.MarriedCount)
  {
    this.Animal.SearchGetMarr( form.value.MarriedCount).subscribe((data) => {
      this.AnimalsAll=data;
      console.log( this.AnimalsAll[0]);

    },
    (err) => {
      console.log(err);
    });
  }
  else if(form.value.Type)
  {
    this.Animal.SearchGettype( form.value.Type).subscribe((data) => {
      this.AnimalsAll=data;
      console.log( this.AnimalsAll[0]);

    },
    (err) => {
      console.log(err);
    });
  }
    else if(form.value.address)
    {
      this.Animal.SearchGetaddress( form.value.address).subscribe((data) => {
        this.AnimalsAll=data;
        console.log( this.AnimalsAll[0]);

      },
      (err) => {
        console.log(err);
      });
    }
    else if(form.value.age)
    {
      this.Animal.SearchGetAge( form.value.age).subscribe((data) => {
        this.AnimalsAll=data;
        console.log( this.AnimalsAll[0]);

      },
      (err) => {
        console.log(err);
      });
    }
    else if(form.value.category)
    {
      this.Animal.SearchGetcategory( form.value.category).subscribe((data) => {
        this.AnimalsAll=data;
        console.log( this.AnimalsAll[0]);

      },
      (err) => {
        console.log(err);
      });
    }
    else if(form.value.gander)
    {
      this.Animal.SearchGetgander( form.value.gander).subscribe((data) => {
        this.AnimalsAll=data;
        console.log( this.AnimalsAll[0]);

      },
      (err) => {
        console.log(err);
      });
    }
   else{
      this.Animal.getAllDoctors().subscribe((data) => {
        this.AnimalsAll=data;
        console.log( this.AnimalsAll[0]);

      },
      (err) => {
        console.log(err);
      });    }
    form.reset();




  }
}

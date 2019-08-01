import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePetsComponent } from './HomePets.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule
  ],
  exports:[HomePetsComponent],
  declarations: [HomePetsComponent]
})
export class HomePetsModule { }

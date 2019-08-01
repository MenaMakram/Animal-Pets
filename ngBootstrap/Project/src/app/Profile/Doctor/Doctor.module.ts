import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorComponent } from './Doctor.component';
import { FormsModule } from '@angular/forms';
import { SafePipe } from '../Safe.pipe';
import { SafesPipe } from './safes.pipe';

@NgModule({
   imports: [
      CommonModule,
      FormsModule,
      NgbModule
   ],
   exports: [
      DoctorComponent
   ],
   declarations: [
      DoctorComponent,
      SafesPipe
   ]
})
export class DoctorModule { }

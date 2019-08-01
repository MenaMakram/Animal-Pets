import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './Search.component';
import { AnimalComponent } from './animal/animal.component';
import { DoctorComponent } from './doctor/doctor.component';
import { TrainersComponent } from './trainers/trainers.component';
import { HomePetsComponent } from './home-pets/home-pets.component';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    AppRoutingModule,
    FormsModule,
    NgxPaginationModule,
    HttpClientModule
  ],
  declarations: [
    SearchComponent,
    AnimalComponent,
    DoctorComponent,
    TrainersComponent,
    HomePetsComponent
]
})
export class SearchModule { }

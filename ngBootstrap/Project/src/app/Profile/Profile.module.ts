import { TrainerComponent } from './Trainer/Trainer.component';
import {  HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './Profile.component';
import { TrainerModule } from './Trainer/Trainer.module';
import { AppRoutingModule } from '../app-routing.module';
import { HomePetsModule } from './HomePets/HomePets.module';
import { DoctorModule } from './Doctor/Doctor.module';
import { FormsModule } from '@angular/forms';
import { ClientModule } from './Client/Client.module';
import { SafePipe } from './Safe.pipe';


@NgModule({
   imports: [
      CommonModule,
      FormsModule,
      TrainerModule,
      HomePetsModule,
      ClientModule,
      DoctorModule,
      AppRoutingModule,
      HttpClientModule
   ],
   declarations: [
      ProfileComponent,
      SafePipe
   ]
})
export class ProfileModule { }

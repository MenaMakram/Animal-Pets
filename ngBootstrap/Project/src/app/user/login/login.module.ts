import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
   imports: [
     BrowserModule,
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
   ],
   declarations: [
      LoginComponent
   ]
})
export class LoginModule { }

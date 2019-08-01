import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Users } from '../Models/Users';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  hasClinic: boolean;

  constructor(private fb: FormBuilder, private http: HttpClient) {

  }
  Header: any;
  formModel = this.fb.group({

    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    Phone: [''],
    Address: [''],
    AvailablePlace: [''],
    OverView: ['', Validators.required],
    JobTitle: ['', Validators.required],
    TrainePlace: ['', Validators.required],
    Courses: ['', Validators.required],
    Description: [''],
    DoctorClinics: '',
    HasClinic: [''],
    PriceForNight: [''],
    NumberOfRooms: [''],
    PricePerHour: ['', Validators.required],
    TypeRegistration: ['', Validators.required],
    ConfirmPassword: ['', Validators.required],
    Password: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })


  });
  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value) {
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      }
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }


  register(body: Users) {
    body.Password = this.formModel.get('Passwords.Password').value;
    body.HasClinic = this.formModel.get('HasClinic').value;
    var reqHeader = new HttpHeaders({'No-Auth': 'True'});

    console.log(body.Password);

    return this.http.post(environment.API_URL + 'Register', body, {headers: reqHeader});
  }
  Login(UserName, Password) {

    console.log("service");
    var data = 'UserName=' + UserName + '&Password=' + Password + '&grant_type=password';
    console.log(data);
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True'});
    return this.http.post<any>('http://localhost:61646/token', data, { headers: reqHeader });
  }
  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var userRoles: string[] = JSON.parse(localStorage.getItem('userRoles'));
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
  getUserClaims() {
    var reqHeader = new HttpHeaders({'Auth': 'True'});
    return this.http.get<any>(environment.API_URL + 'GetUserClaims',{headers:reqHeader});
  }
}

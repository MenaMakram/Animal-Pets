import { UserService } from './../../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Users } from 'src/app/Models/Users';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./main.css']
})
export class RegistrationComponent implements OnInit {
 Roles=['Doctor','Trainer','House'];
selectedRole: string;
doctorDiv: boolean;
TrainerDiv: boolean;
House: boolean;
UserForm: FormGroup;
user: Users;
clientDiv: boolean = true;
hasClinic: boolean = false;
showAlert: boolean = false;
 constructor(public service: UserService, private toastr: ToastrService ,private formbulider: FormBuilder) { }

  ngOnInit() {

   }
   onItemChange(event:any){
    this.hasClinic= event.target.value;
   }

  // comparePasswords(fb: FormGroup) {
  //   let confirmPswrdCtrl = fb.get('ConfirmPassword');
  //   //passwordMismatch
  //   //confirmPswrdCtrl.errors={passwordMismatch:true}
  //   if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
  //     if (fb.get('Password').value != confirmPswrdCtrl.value)
  //       confirmPswrdCtrl.setErrors({ passwordMismatch: true });
  //     else
  //       confirmPswrdCtrl.setErrors(null);
  //   }
  // }

  onSubmit() {
    const user =this.service.formModel.value;
    console.log(this.service.formModel.value);
    this.service.register(user).subscribe(
          (data: any) => {
        if (data.Succeeded == true) {
          this.showAlert=true;
          // alert("User registration successful");
          this.service.formModel.reset();
          // this.toastr.success('User registration successful');
          Swal.fire({
            position: 'top-end',
            type: 'success',
            title: 'User registration successful',
            showConfirmButton: false,
            timer: 1500
          });
        }
        else
         {
          Swal.fire({
            type: 'error',
            title: data.Errors[0],
            text:data.Errors[1],

          })}
      });
  }

  changeRole(event:any){
  this.selectedRole= event.target.value;
  if(this.selectedRole == this.Roles[0])
     {
       this.doctorDiv=true;
       this.TrainerDiv=false;
       this.House=false;
       this.clientDiv=false;
     }
    else  if(this.selectedRole == this.Roles[1])
     {
       this.doctorDiv=false;
       this.TrainerDiv=true;
       this.House=false;
       this.clientDiv=false;
     }
     else  if(this.selectedRole == this.Roles[2])
     {
       this.doctorDiv=false;
       this.TrainerDiv=false;
       this.House=true;
       this.clientDiv=false
     }
     else{

      this.doctorDiv=false;
       this.TrainerDiv=false;
       this.House=false;
       this.clientDiv=true;
     }

  console.log(this.selectedRole);
  }
  goNext(){

  }
}

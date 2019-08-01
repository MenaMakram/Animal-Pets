import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { query } from '@angular/animations';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  errorMessage: string;
  constructor(private router: Router, private LoginService: UserService) { }
  ngOnInit() {
    sessionStorage.removeItem('UserName');
    sessionStorage.clear();
  }
  Login(UserName: any, Password: any) {

    this.LoginService.Login(UserName, Password).subscribe(
      data => {
        console.log("data "+JSON.stringify(data));
        if (data.access_token != "") {

          console.log("tsT");
          localStorage.setItem('userToken', data.access_token);
          localStorage.setItem('userRoles', data.role);
          this.LoginService.getUserClaims().subscribe(data1 => {
            console.log("data1 "+JSON.stringify(data1));
            this.router.navigate(['/Profile'],{queryParams :
              {
              Id: data1.ID
              }});

          });
        }
        else {
          console.log("tsF");
          this.errorMessage = data.Message;
        }
      },
      error => {
        this.errorMessage = 'Login Failed';
      });
  };

}

import { Component } from '@angular/core';
import {NgbModal, NgbModalConfig} from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/Services/User';
import { UserService } from './shared/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Pets';
  usersId: string;

  constructor(public userservice: UserService,protected router: Router)
  {
    this.userservice.getUserClaims().subscribe(data => {
      this.usersId = data.ID;
    });
  }
  Logout()
  {
    localStorage.removeItem('userToken');
    localStorage.removeItem('userRoles');
    this.router.navigate(['/login']);
  }
}

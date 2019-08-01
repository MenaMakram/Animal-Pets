import { UserComponent } from './user.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RegisterModule } from './registration/registration.module';
import { LoginModule } from './login/login.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserService } from '../Shared/user.service';
import { AuthGuard } from '../auth/auth.guard';
import { AuthInterceptor } from '../auth/auth.interceptor';


@NgModule({
   imports: [
      CommonModule,
      FormsModule,
      AppRoutingModule,
      HttpClientModule,
      RegisterModule,
      LoginModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot({
        progressBar: true
      })
   ],
   providers: [UserService ,AuthGuard,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }],
   declarations: [
      UserComponent
   ]
})
export class UserModule { }

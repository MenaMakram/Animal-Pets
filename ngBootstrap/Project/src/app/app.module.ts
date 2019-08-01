import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProfileModule } from './Profile/Profile.module';
import { UserModule } from './user/user.module';
import { AuthGuard } from './auth/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/auth.interceptor';
import { PostsComponent } from './posts/posts.component';
import { MyPostComponent } from './my-post/my-post.component';
import { UpdatePostComponent } from './update-post/update-post.component';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { FormsModule } from '@angular/forms';
import {NgxPaginationModule} from 'ngx-pagination';
import { SearchModule } from './Search/Search.module';
import { SafesaPipe } from './posts/safesa.pipe';

@NgModule({
  declarations: [
    AppComponent,
    PostsComponent,
    MyPostComponent,
    UpdatePostComponent,
    ConfirmationDialogComponent,
    SafesaPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProfileModule,
    UserModule,
    NgbModule,
    FormsModule,
    SearchModule,
    NgxPaginationModule
  ],
  providers: [ AuthGuard,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }],
  exports: [AppComponent],
  bootstrap: [AppComponent],
  entryComponents:[ConfirmationDialogComponent]
})
export class AppModule { }

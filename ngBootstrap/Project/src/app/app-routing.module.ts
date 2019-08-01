import { SearchRoutes } from './Search/Search.routing';
import { UserRoutes } from './user/user.routing';
import { ProfileRoutes } from './Profile/Profile.routing';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyPostComponent } from './my-post/my-post.component';
import { UpdatePostComponent } from './update-post/update-post.component';
import { PostsComponent } from './posts/posts.component';




const routes: Routes = [
  {
    path: '',
    redirectTo: '/Posts',
    pathMatch: 'full'
  },
  { path: 'Posts', component:  PostsComponent },
  { path: 'MyPostComponent', component: MyPostComponent },
  { path: 'UpdatePostComponent/:id', component: UpdatePostComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    ProfileRoutes,
    UserRoutes,
    SearchRoutes,
  ],
  exports: [
    RouterModule
  ],
  declarations: [
  ]
})
export class AppRoutingModule { }

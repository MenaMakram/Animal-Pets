import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './Profile.component';
import { AuthGuard } from '../auth/auth.guard';

const routes: Routes = [
  { path: 'Profile', component: ProfileComponent,canActivate: [AuthGuard]},
//   {path: 'Trainer', component: ProfileComponent,
// children:[{path:'',component:TrainerComponent}]
// },
// {path: 'HomePets', component: ProfileComponent,
// children:[{path:'',component:HomePetsComponent}]
// },
// {path: 'Client', component: ProfileComponent,
// children:[{path:'',component:ClientComponent}]
// },
];

export const ProfileRoutes = RouterModule.forChild(routes);

import { SearchComponent } from './Search.component';
import { Routes, RouterModule } from '@angular/router';
import { TrainersComponent } from './trainers/trainers.component';
import { AnimalComponent } from './animal/animal.component';
import { HomePetsComponent } from './home-pets/home-pets.component';
import { DoctorComponent } from './doctor/doctor.component';

const routes: Routes = [
  {path: 'Trainers', component: SearchComponent,
  children: [{path: '', component: TrainersComponent}]},
  {path: 'HomePets', component: SearchComponent,
  children: [{path: '', component: HomePetsComponent}]},
  {path: 'Doctors', component: SearchComponent,
  children: [{path: '', component: DoctorComponent}]},
  {path: 'Animals', component: SearchComponent,
  children: [{path: '', component: AnimalComponent}]}
];

export const SearchRoutes = RouterModule.forChild(routes);

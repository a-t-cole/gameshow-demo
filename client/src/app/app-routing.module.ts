import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WallroundComponent } from './wall/wallround/wallround.component';

const routes: Routes = [
  {
    path: 'wall', 
    loadChildren: () => import('src/app/wall/wall.module').then((mod) => mod.WallModule)
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/wall'
  },
  {
    path:'**',
    redirectTo: ''
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

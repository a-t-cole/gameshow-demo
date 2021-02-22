import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { WallroundComponent } from "./wallround/wallround.component";

const routes: Routes = [
    {
        path: '', 
        pathMatch:'full',
        component: WallroundComponent
    }
]; 

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WallRoutingModule { }
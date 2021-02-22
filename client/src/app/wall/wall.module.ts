import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestComponent } from './test/test.component';
import { WallRoutingModule } from './wall-routing.module';
import { WallroundComponent } from './wallround/wallround.component';
import { WallItemComponent } from './wall-item/wall-item.component';



@NgModule({
  declarations: [WallroundComponent, TestComponent, WallItemComponent],
  imports: [
    CommonModule,
    WallRoutingModule
  ]
})
export class WallModule { }

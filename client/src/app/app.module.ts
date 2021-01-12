import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { WallroundComponent } from './components/wallround/wallround.component';
import { WallitemComponent } from './components/wallitem/wallitem.component';

@NgModule({
  declarations: [
    AppComponent,
    WallroundComponent,
    WallitemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({
      timeOut: 3000, 
      positionClass: 'toast-bottom-center', 
      maxOpened: 3, 
      countDuplicates: true, 
      closeButton: true, 
      progressBar: true, 
      tapToDismiss: true, 
      resetTimeoutOnDuplicate: true
    }), // ToastrModule added
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

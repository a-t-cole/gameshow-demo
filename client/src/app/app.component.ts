import { Component, OnInit } from '@angular/core';
import { PushService } from './services/push.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  constructor(private pushSvc: PushService){
    
  }
  ngOnInit(): void {
    this.pushSvc.startConnection();
    this.pushSvc.MessageReceived.subscribe(x => {
      if(x){
        console.log(x);
      }
    })
  }
}

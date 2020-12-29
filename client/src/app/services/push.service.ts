import { EventEmitter, Injectable, OnDestroy, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';
import { GenericKeyValuePair } from '../models/generic.models';

@Injectable({
  providedIn: 'root'
})
export class PushService implements OnInit, OnDestroy{

  public MessageReceived = new EventEmitter<GenericKeyValuePair<string, any>>(); 
  private _hubConnection: HubConnection; 
  private readonly _methods: string[] = ["Message"];
  constructor() { }
  ngOnDestroy(): void {
    if(this._hubConnection && this._hubConnection.state == HubConnectionState.Connected){
      for(let method of this._methods){
        try{
          this._hubConnection.off(method);
        }catch{

        }
      }
    }
  }
  ngOnInit(): void {
    this.startConnection(); 
  }
  startConnection():void{
    if(this._hubConnection === undefined || this._hubConnection === null){
      this._hubConnection = new HubConnectionBuilder().withUrl(environment.pushServer).build(); 
      this._hubConnection.start()
      .then(() => {
        for(let method of this._methods){
          this._hubConnection.on(method, (message, user, test) => {
            if(message){
              this.MessageReceived.emit(new GenericKeyValuePair(method, message));
            }
          });
        }
      }).catch((e) => {
        console.log('Could not start connection:'+e);
      })

    }
  }
}

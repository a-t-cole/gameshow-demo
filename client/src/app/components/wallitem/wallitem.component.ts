import { Component, Input, OnInit } from '@angular/core';
import { WallConnectionItem } from 'src/app/models/questions.models';

@Component({
  selector: 'oc-wallitem',
  templateUrl: './wallitem.component.html',
  styleUrls: ['./wallitem.component.scss']
})
export class WallitemComponent implements OnInit {

  @Input() item: WallConnectionItem
  @Input() forceBackground: number = 0; 
  constructor() { }

  ngOnInit(): void {
  }
  getStyles(): string{
    let result: string = 'ungrouped';
    if(this.forceBackground){
      return `group${this.forceBackground.toString()}`; 
    }
    if(this.item.IsSelected){
      result += "selected";   
    }
    return result; 
  }
}

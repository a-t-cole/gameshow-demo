import { Component, Input, OnInit } from '@angular/core';
import { WallConnectionItem } from 'src/app/models/questions.models';

@Component({
  selector: 'oc-wall-item',
  templateUrl: './wall-item.component.html',
  styleUrls: ['./wall-item.component.scss']
})
export class WallItemComponent implements OnInit {

  @Input() Item: WallConnectionItem = null; 
  constructor() { }

  ngOnInit(): void {
  }

}

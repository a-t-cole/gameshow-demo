import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'oc-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  @Input() Name: string = 'none';
  constructor() { }

  ngOnInit(): void {
  }

}

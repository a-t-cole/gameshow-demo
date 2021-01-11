import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DummyData } from 'src/app/dummydata.helper';
import { WallConnectionItem, WallGroup } from 'src/app/models/questions.models';

@Component({
  selector: 'oc-wallround',
  templateUrl: './wallround.component.html',
  styleUrls: ['./wallround.component.scss']
})
export class WallroundComponent implements OnInit {

  public wall: WallGroup[]; 
  private _selectedCount: number = 0;
  public remainingLives: number = Infinity; 
  public wallFrozen: boolean = false; 
  constructor(private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.wall = this.loadWall();
  }
  loadWall() : WallGroup[]{
    return DummyData.getWallGroup(); 
  }
  onItemtap(item: WallConnectionItem){
    item.IsSelected = !item.IsSelected
    if(item.IsSelected){
      this._selectedCount +=1; 
      if(this._selectedCount == 4){
        if(!this.validateSelection(this.wall) && this.remainingLives < Infinity){
          this.remainingLives -= 1; 
        } 
        if(this.remainingLives == 0){
          this.wallFrozen = true; 
        }else{
          this.clearSelection(this.wall); 
        }
      }
    }else if(this._selectedCount > 0){
      this._selectedCount -= 1; 
    }
  }

  validateSelection(wall: WallGroup[]): boolean{
    let correctAnswer: boolean = false; 
    if(wall.map(x => x.IsAnswered == true).length == 2 && this.remainingLives == Infinity){
      this.remainingLives = 3; 
    }
    for(let w of wall){
      if(w.IsAnswered){
        continue; 
      }
      if(w.Items.map(x => x.IsSelected).length == 4){
        //They have all 4 items selected. 
        w.IsAnswered = true; 
        correctAnswer = true; 
        break; 
      }
    }
    return correctAnswer; 
  }
  clearSelection(wall: WallGroup[]){
    for(let w of wall){
      if(w.IsAnswered){
        continue; 
      }
      w.Items.forEach(x => x.IsSelected = false);
    }
  }
}

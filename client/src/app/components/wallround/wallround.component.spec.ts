import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DummyData } from 'src/app/dummydata.helper';
import { WallroundComponent } from './wallround.component';


describe('WallroundComponent', () => {
  let component: WallroundComponent;
  let fixture: ComponentFixture<WallroundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WallroundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WallroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should unshuffle a group', () => {
    let wallItems = component.getWallItems(DummyData.getWallGroup()); 
       
    let sorted = component.unshuffleGroup(3, wallItems);
    for(let i = 0; i< sorted.length; i++){
      if(i<4){
        expect(sorted[i].GroupId).toBe(3);
      }else{
        expect(sorted[i].GroupId).not.toBe(3); 
      }
    }
    
  });
});

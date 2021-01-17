import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { DummyData } from 'src/app/dummydata.helper';
import { WallroundComponent } from './wallround.component';


describe('WallroundComponent', () => {
  let component: WallroundComponent;
  let fixture: ComponentFixture<WallroundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule ], 
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
    component.wallItems = wallItems;
    component.handleCompleteGroup(1);
    expect(component.wallItems.every(x => x.GroupId != 1)).toBeTrue(); 
    expect(component.completeGroups.every(x => x.GroupId == 1)).toBeTrue(); 
    
  });
});

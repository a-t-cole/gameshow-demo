import { async, ComponentFixture, TestBed } from '@angular/core/testing';

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
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WallitemComponent } from './wallitem.component';

describe('WallitemComponent', () => {
  let component: WallitemComponent;
  let fixture: ComponentFixture<WallitemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WallitemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WallitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

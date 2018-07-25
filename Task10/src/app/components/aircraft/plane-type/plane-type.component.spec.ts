import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneTypeComponent } from './plane-type.component';

describe('PlaneTypeComponent', () => {
  let component: PlaneTypeComponent;
  let fixture: ComponentFixture<PlaneTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaneTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

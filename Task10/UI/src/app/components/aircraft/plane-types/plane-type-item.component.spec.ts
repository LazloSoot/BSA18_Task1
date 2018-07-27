import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneTypeItemComponent } from './plane-type-item.component';

describe('PlaneTypeItemComponent', () => {
  let component: PlaneTypeItemComponent;
  let fixture: ComponentFixture<PlaneTypeItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaneTypeItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneTypeItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

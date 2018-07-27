import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneItemComponent } from './plane-item.component';

describe('PlaneItemComponent', () => {
  let component: PlaneItemComponent;
  let fixture: ComponentFixture<PlaneItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaneItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

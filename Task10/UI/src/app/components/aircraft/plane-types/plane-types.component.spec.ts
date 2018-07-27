import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneTypesComponent } from './plane-types.component';

describe('PlaneTypesComponent', () => {
  let component: PlaneTypesComponent;
  let fixture: ComponentFixture<PlaneTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaneTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

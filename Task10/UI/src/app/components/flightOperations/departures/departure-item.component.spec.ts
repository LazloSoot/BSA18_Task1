import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartureItemComponent } from './departure-item.component';

describe('DepartureItemComponent', () => {
  let component: DepartureItemComponent;
  let fixture: ComponentFixture<DepartureItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartureItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartureItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

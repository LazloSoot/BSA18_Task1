import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrewItemComponent } from './crew-item.component';

describe('CrewItemComponent', () => {
  let component: CrewItemComponent;
  let fixture: ComponentFixture<CrewItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrewItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrewItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

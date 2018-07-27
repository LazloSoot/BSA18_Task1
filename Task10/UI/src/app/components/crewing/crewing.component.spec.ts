import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrewingComponent } from './crewing.component';

describe('CrewingComponent', () => {
  let component: CrewingComponent;
  let fixture: ComponentFixture<CrewingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrewingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrewingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

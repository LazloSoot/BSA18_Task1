import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StewardessesComponent } from './stewardesses.component';

describe('StewardessesComponent', () => {
  let component: StewardessesComponent;
  let fixture: ComponentFixture<StewardessesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StewardessesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StewardessesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

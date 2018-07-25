import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StewardessComponent } from './stewardess.component';

describe('StewardessComponent', () => {
  let component: StewardessComponent;
  let fixture: ComponentFixture<StewardessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StewardessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StewardessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

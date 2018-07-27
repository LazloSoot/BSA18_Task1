import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StewardessItemComponent } from './stewardess-item.component';

describe('StewardessItemComponent', () => {
  let component: StewardessItemComponent;
  let fixture: ComponentFixture<StewardessItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StewardessItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StewardessItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

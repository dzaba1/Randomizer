import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FastRandomComponent } from './fast-random.component';

describe('FastRandomComponent', () => {
  let component: FastRandomComponent;
  let fixture: ComponentFixture<FastRandomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FastRandomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FastRandomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

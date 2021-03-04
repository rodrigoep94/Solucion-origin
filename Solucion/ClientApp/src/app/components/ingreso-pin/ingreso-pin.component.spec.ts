import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IngresoPinComponent } from './ingreso-pin.component';

describe('IngresoPinComponent', () => {
  let component: IngresoPinComponent;
  let fixture: ComponentFixture<IngresoPinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IngresoPinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IngresoPinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

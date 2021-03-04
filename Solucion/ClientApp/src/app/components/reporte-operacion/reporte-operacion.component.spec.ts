import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteOperacionComponent } from './reporte-operacion.component';

describe('ReporteOperacionComponent', () => {
  let component: ReporteOperacionComponent;
  let fixture: ComponentFixture<ReporteOperacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReporteOperacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteOperacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

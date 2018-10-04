import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VwListadosComponent } from './vw-listados.component';

describe('VwListadosComponent', () => {
  let component: VwListadosComponent;
  let fixture: ComponentFixture<VwListadosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VwListadosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VwListadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

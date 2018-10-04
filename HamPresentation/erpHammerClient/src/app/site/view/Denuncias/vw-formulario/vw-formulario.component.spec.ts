import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VwFormularioComponent } from './vw-formulario.component';

describe('VwFormularioComponent', () => {
  let component: VwFormularioComponent;
  let fixture: ComponentFixture<VwFormularioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VwFormularioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VwFormularioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DropZonificacionComponent } from './drop-zonificacion.component';

describe('DropZonificacionComponent', () => {
  let component: DropZonificacionComponent;
  let fixture: ComponentFixture<DropZonificacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropZonificacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropZonificacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

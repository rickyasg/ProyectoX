import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DropParametrosComponent } from './drop-parametros.component';

describe('DropParametrosComponent', () => {
  let component: DropParametrosComponent;
  let fixture: ComponentFixture<DropParametrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropParametrosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropParametrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

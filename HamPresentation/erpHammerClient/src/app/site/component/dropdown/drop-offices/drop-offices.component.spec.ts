import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DropOfficesComponent } from './drop-offices.component';

describe('DropOfficesComponent', () => {
  let component: DropOfficesComponent;
  let fixture: ComponentFixture<DropOfficesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropOfficesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropOfficesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

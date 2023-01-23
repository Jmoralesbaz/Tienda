import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StructAccessComponent } from './struct-access.component';

describe('StructAccessComponent', () => {
  let component: StructAccessComponent;
  let fixture: ComponentFixture<StructAccessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StructAccessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StructAccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

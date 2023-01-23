import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StructPanelComponent } from './struct-panel.component';

describe('StructPanelComponent', () => {
  let component: StructPanelComponent;
  let fixture: ComponentFixture<StructPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StructPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StructPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

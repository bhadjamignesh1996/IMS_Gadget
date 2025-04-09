import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGadgetModalComponent } from './add-gadget-modal.component';

describe('AddGadgetModalComponent', () => {
  let component: AddGadgetModalComponent;
  let fixture: ComponentFixture<AddGadgetModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGadgetModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddGadgetModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

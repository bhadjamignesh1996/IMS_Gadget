import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonApiService, CommonService } from 'src/app/services';

@Component({
  selector: 'app-add-gadget-modal',
  templateUrl: './add-gadget-modal.component.html',
})
export class AddGadgetModalComponent {
  addGadgetForm!: FormGroup;
  @Input() gadgetId!: number;
  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<any>();

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private commonApiService: CommonApiService,
    public commonService: CommonService,
  ) {
    this.addGadgetForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      brand: ['', [Validators.required]],
      category: ['', [Validators.required]],
      price: [0, [Validators.required, Validators.min(10)]],
      quantity: [0, [Validators.required, Validators.min(5)]],
      description: ['', [Validators.required]],
      secretInfo: ['', [Validators.required]],
    });

  }

  ngOnChanges(){
    if (this.gadgetId != null && this.gadgetId > 0) {
      this.getGadgetById()
    }
  }

  saveGadget() {
    if (this.addGadgetForm.invalid) {
      this.addGadgetForm.markAllAsTouched();
      return;
    }
    var requestData = this.addGadgetForm.value;
    requestData.secretInfo = this.commonService.encrypt(requestData.secretInfo);

    this.commonApiService.postRequest("Gadget/UpsertGadget", requestData).subscribe((res) => {
      if (res) {
        this.save.emit(res);
      }
    })
  }
  onClose() {
    this.close.emit();
    this.addGadgetForm.reset();
  }

  getGadgetById() {
    if (this.gadgetId != null && this.gadgetId > 0) {
      this.commonApiService.getRequest("Gadget/GetGadgetById/" + this.gadgetId).subscribe((res) => {
        if (res) {
          this.commonService.setEditData(this.addGadgetForm,res.data);
        }
      })
    }
  }



}

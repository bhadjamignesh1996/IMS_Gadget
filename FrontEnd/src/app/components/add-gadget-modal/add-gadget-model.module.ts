import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddGadgetModalComponent } from './add-gadget-modal.component';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [AddGadgetModalComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule
  ],
  exports:[AddGadgetModalComponent]
})
export class AddGadgetModalModule {}

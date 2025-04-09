import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { GadgetListComponent } from './gadget-list.component';
import { AddGadgetModalModule } from '../add-gadget-modal/add-gadget-model.module';


const routes: Routes = [{ path: '', component: GadgetListComponent }];

@NgModule({
  declarations: [GadgetListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
    AddGadgetModalModule
  ],
})
export class GadgetListModule {}

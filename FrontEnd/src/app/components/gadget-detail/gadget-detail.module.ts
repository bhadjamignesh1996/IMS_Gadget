import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { GadgetDetailComponent } from './gadget-detail.component';



const routes: Routes = [{ path: '', component: GadgetDetailComponent }];

@NgModule({
  declarations: [GadgetDetailComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
  ],
})
export class GadgetDetailsModule {}

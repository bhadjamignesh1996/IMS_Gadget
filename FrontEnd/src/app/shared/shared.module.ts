import { NgModule } from '@angular/core';
import { ShowErrorModule } from '../components/show-error/show-error.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [RouterModule],
  exports: [ShowErrorModule, ReactiveFormsModule],
})
export class SharedModule {}

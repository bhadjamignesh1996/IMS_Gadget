import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { AuthGuard } from './helpers/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'login',
    loadChildren: () =>
      import('./components/login/login.module').then((m) => m.LoginModule)
  },
  {
    path: 'gadgets',
    loadChildren: () =>
      import('./components/gadget-list/gadget-list.module').then((m) => m.GadgetListModule),
    canActivate:[AuthGuard]
  },
  { path: 'gadget/:id', loadChildren: () =>
    import('./components/gadget-detail/gadget-detail.module').then((m) => m.GadgetDetailsModule),
    canActivate:[AuthGuard]  },
  { path: 'unauthorized', component: UnauthorizedComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

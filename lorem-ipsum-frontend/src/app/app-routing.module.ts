import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteDetailsComponent } from './components/cliente-details/cliente-details.component';
import { ClienteComponent } from './components/cliente-list/cliente.component';

const routes: Routes = [
  { path: '', component: ClienteComponent },
  { path: 'cliente/:id', component: ClienteDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

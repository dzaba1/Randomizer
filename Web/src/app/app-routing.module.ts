import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FastRandomComponent } from './fast-random/fast-random.component';

const routes: Routes = [
  { path: '', component: FastRandomComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

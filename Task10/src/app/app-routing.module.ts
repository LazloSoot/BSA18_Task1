import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightsComponent } from './components/flightOperations/flight/flight.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/flights'
  },
  {
    path: 'flights',
    component: FlightsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NewAdComponent } from './new-ad/new-ad.component';
import { OffersComponent } from './offers/offers.component';
import { HomeComponent } from './home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
 
const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'offers', component: OffersComponent},
  {path: 'newad', component: NewAdComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from 'src/home-page/home-page.component';
import { LoginPageComponent } from 'src/login-page/login-page.component';

const routes: Routes = [
  {path:"HomePage😵😵",component:HomePageComponent},
  {path:"LoginPage🥴🥴",component:LoginPageComponent},
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
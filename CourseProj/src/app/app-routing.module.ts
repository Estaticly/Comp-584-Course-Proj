import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShoeFeedComponent } from './shoe-feed/shoe-feed.component';
import { ShoeInventroyComponent } from './shoe-inventroy/shoe-inventroy.component';
import { LoginComponent } from './auth/login.component';
import { ShoeByBrandComponent } from './shoe-feed/shoe-by-brand.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  {path:'shoe-feed', component: ShoeFeedComponent},
  {path:'shoe-inventory', component: ShoeInventroyComponent},
  { path: 'login', component: LoginComponent },
  {path: 'shoe-by-brand/:id',component: ShoeByBrandComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

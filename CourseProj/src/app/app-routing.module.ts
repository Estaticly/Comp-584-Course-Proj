import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShoeFeedComponent } from './shoe-feed/shoe-feed.component';
import { ShoeInventroyComponent } from './shoe-inventroy/shoe-inventroy.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  {path:'shoe-feed', component: ShoeFeedComponent},
  {path:'shoe-inventory', component: ShoeInventroyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

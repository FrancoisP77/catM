import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatlistComponent } from './Cats/catlist/catlist.component';
import { CatmashComponent } from './Cats/catmash/catmash.component';

const routes: Routes = [
  { path: 'catScores', component: CatlistComponent, title: "Cat mash - list" },
  { path: '', component: CatmashComponent, title: "Cat mash - vote now" },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoreComponent } from './core/core.component';

const routes: Routes = [
  { path: '', redirectTo : 'cats', pathMatch: 'full'},
  {
    path: '',
    component: CoreComponent,
    children: [
      {path: 'cats', loadChildren: './cats-vote/cats-vote.module#CatsVoteModule'}
    ],
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VoteComponent } from './vote/vote.component';
import { ScoreComponent } from './score/score.component';
import { RouterModule, Routes } from '@angular/router';
import { MaterialModule } from '../material.module';

const routes: Routes = [
  { path: '', redirectTo : 'vote', pathMatch: 'full'},
  { path: 'vote', component: VoteComponent},
  { path: 'score', component: ScoreComponent}
]


@NgModule({
  declarations: [
    VoteComponent, 
    ScoreComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MaterialModule
  ]
})
export class CatsVoteModule { }

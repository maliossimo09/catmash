import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { CoreComponent } from './core.component';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CatsVoteModule } from '../cats-vote/cats-vote.module';

@NgModule({
  declarations: [
    HeaderComponent, 
    CoreComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    FontAwesomeModule
    
  ]
})
export class CoreModule { }

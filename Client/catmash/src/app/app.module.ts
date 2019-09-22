import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UrlService } from 'src/shared/services/url-service/url-service.service';
import { CoreModule } from './core/core.module';
import { MaterialModule } from './material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CatService } from 'src/shared/services/cat-service/cat.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    MaterialModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    HttpClientModule 
  ],
  providers: [
    UrlService,
    CatService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

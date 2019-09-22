import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UrlService } from 'src/shared/services/url-service/url-service.service';
import { CoreModule } from './core/core.module';
import { MaterialModule } from './material.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    MaterialModule,
    BrowserAnimationsModule
  ],
  providers: [
    UrlService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
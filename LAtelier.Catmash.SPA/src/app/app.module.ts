import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { CatmashComponent } from './Cats/catmash/catmash.component';
import { CatlistComponent } from './Cats/catlist/catlist.component';
import { CatdetailsComponent } from './Cats/catdetails/catdetails.component';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { API_URL } from 'src/common.settings';

@NgModule({
  declarations: [
    AppComponent,
    CatmashComponent,
    CatlistComponent,
    CatdetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
  /* We may want to create settings.js file to feed our settings from. */
    { provide: API_URL, useValue: "https://catmash.latelier.m-h.fr"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

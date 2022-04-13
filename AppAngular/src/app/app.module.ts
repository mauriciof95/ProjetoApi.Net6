import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';
import { CustomFormsModule } from 'ng2-validation';
import { NavegationModule } from './modules/navegation.module';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    NavegationModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    TextMaskModule,
    NgBrazil,
    CustomFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

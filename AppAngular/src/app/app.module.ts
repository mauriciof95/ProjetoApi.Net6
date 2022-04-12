import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HomeComponent } from './pages/home/home.component';
import { NavMenuComponent } from './Components/Layout/nav-menu/nav-menu.component';
import { FooterComponent } from './Components/Layout/footer/footer.component';
import { ListarClienteComponent } from './pages/clientes/lista/listar-clientes.component';
import { CadastrarClienteComponent } from './pages/clientes/cadastrar-cliente/cadastrar-cliente.component';
import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    ListarClienteComponent,
    CadastrarClienteComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    TextMaskModule,
    NgBrazil,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

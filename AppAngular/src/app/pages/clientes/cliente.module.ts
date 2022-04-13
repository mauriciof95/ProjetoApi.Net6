import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { ReactiveFormsModule } from '@angular/forms';
import { ClienteRoutingModule } from "./cliente.route";
import { CadastrarClienteComponent } from "./cadastrar-cliente/cadastrar-cliente.component";
import { ListarClienteComponent } from "./lista/listar-clientes.component";

@NgModule({
  declarations: [
    CadastrarClienteComponent,
    ListarClienteComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ClienteRoutingModule
  ],
  exports: [

  ]
})
export class ClienteModule{}

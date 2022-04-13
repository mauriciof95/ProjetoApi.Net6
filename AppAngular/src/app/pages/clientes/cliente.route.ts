import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarClienteComponent } from './cadastrar-cliente/cadastrar-cliente.component';
import { ListarClienteComponent } from './lista/listar-clientes.component';

const clienteRoutes: Routes = [
  {path: '', component: ListarClienteComponent},
  {path: 'cadastrar', component: CadastrarClienteComponent}
];

@NgModule({
  imports: [RouterModule.forChild(clienteRoutes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarClienteComponent } from './pages/clientes/cadastrar-cliente/cadastrar-cliente.component';
import { ListarClienteComponent } from './pages/clientes/lista/listar-clientes.component';
import { HomeComponent } from './pages/home/home.component';



const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'clientes', component: ListarClienteComponent},
  {path: 'cliente/cadastrar', component: CadastrarClienteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MASKS, NgBrazilValidators } from 'ng-brazil';
import { Cliente } from 'src/app/models/Cliente';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html'
})
export class CadastrarClienteComponent implements OnInit {

  cadastroForm: FormGroup;
  cliente: Cliente | undefined;
  MASKS = MASKS;


  constructor(private fb: FormBuilder) {
    this.cadastroForm = this.fb.group({
      nome: ['', Validators.required],
      documento: ['', [Validators.required, NgBrazilValidators.cpf]]
    });
  }

  ngOnInit() {

  }

  adicionarCliente(){
    this.cliente = Object.assign({}, this.cliente, this.cadastroForm.value);
  }

}

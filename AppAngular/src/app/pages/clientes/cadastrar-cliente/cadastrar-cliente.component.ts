import { AfterViewInit, Component, OnInit, ElementRef, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { NgBrazilValidators } from 'ng-brazil';
import { fromEvent, merge, Observable } from 'rxjs';
import { Cliente } from 'src/app/models/Cliente';
import { DisplayMessage, GenericValidator, ValidationMessages } from 'src/app/utils/generic-form-validation';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html'
})
export class CadastrarClienteComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, {read: ElementRef}) formInputElements: ElementRef[] = [];

  cadastroForm: FormGroup;
  cliente: Cliente | undefined;

  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage = {};

  constructor(private fb: FormBuilder) {
    this.validationMessages = {
      nome: {
        required: 'O Nome é obrigatorio.'
      },
      documento: {
        required: 'O Documento é obrigatorio.',
        cpf: 'CPF invalido.'
      }
    }

    this.genericValidator = new GenericValidator(this.validationMessages);

    this.cadastroForm = this.fb.group({
      nome: ['', Validators.required],
      documento: ['', [Validators.required, NgBrazilValidators.cpf]]
    });
  }

  ngOnInit() {

  }


  ngAfterViewInit(): void {
      let controlBlurs: Observable<any>[] = this.formInputElements
        .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

      merge(...controlBlurs).subscribe(() => {
        this.displayMessage = this.genericValidator.processarMensagens(this.cadastroForm);
      });
  }


  adicionarCliente(){
    this.cliente = Object.assign({}, this.cliente, this.cadastroForm.value);
  }

}

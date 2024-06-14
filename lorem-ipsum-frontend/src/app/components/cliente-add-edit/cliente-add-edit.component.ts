import { CepService } from './../../services/cep.service';
import { Component, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteService } from '../../services/cliente.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CoreService } from '../../core/core.service';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { Endereco } from '../../models/endereco';
import {provideMomentDateAdapter} from '@angular/material-moment-adapter';
import 'moment/locale/pt';


@Component({
  selector: 'app-cliente-add-edit',
  providers: [
    {provide: MAT_DATE_LOCALE, useValue: 'pt-BR'},
    provideMomentDateAdapter()
  ],
  templateUrl: './cliente-add-edit.component.html',
  styleUrl: './cliente-add-edit.component.css'
})



export class ClienteAddEditComponent {

  clienteForm: FormGroup;

  genero: string[] = [
    'Masculino',
    'Feminino'
  ];

  tipoEndereco: string[] = [
    'Residencial',
    'Comercial'
  ];

  constructor(
    private fb: FormBuilder,
    private clienteService: ClienteService,
    private dialogRef: MatDialogRef<ClienteAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private coreService: CoreService,
    private cepService: CepService
  ) {

    this.clienteForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      genero: ['', Validators.required],
      enderecos: this.fb.array([])
    });

  }

  ngOnInit(): void {
    if (this.data) {
      this.data.enderecos.forEach((e: any) => {
        this.addEndereco()
      });
    } else {
      this.addEndereco()
    }
    this.clienteForm.patchValue(this.data);
  }

  get enderecos() {
    return this.clienteForm.controls["enderecos"] as FormArray;
  }

  addEndereco() {
    const enderecoForm = this.fb.group({
        id: [0],
        cep: ['', Validators.required],
        tipoEndereco: ['', Validators.required],
        logradouro: ['', Validators.required],
        localidade: ['', Validators.required],
        uf: ['', Validators.required],
        numero: ['', Validators.required],
        complemento: [''],
        bairro: [''],
    });

    this.enderecos.push(enderecoForm);
  }

  deleteEndereco(index: number) {
    this.enderecos.removeAt(index);
  }

  getCep(e: any, index: any) {
    let cep = e.replace(/\D/g, "")
    if (cep.length === 8) {
      this.cepService.getCep(e).subscribe((endereco: Endereco) => {
        this.enderecos.at(index).patchValue(endereco)
      });
    }
  }

  onFormSubmit() {
    if (this.clienteForm.valid) {
      if (this.data) {
        this.clienteService
          .updateCliente(this.clienteForm.value)
          .subscribe({
            next: (val: any) => {
              this.coreService.openSnackBar('Cliente atualizado');
              this.dialogRef.close(true);
            },
            error: (e: any) => {
              this.coreService.openSnackBar(e.error.message);
            },
          });
      } else {
        this.clienteService.addCliente(this.clienteForm.value).subscribe({
          next: (val: any) => {
            this.coreService.openSnackBar('Cliente salvo');
            this.dialogRef.close(true);
          },
          error: (e: any) => {
            this.coreService.openSnackBar(e.error.message);
          },
        });
      }
    }
  }
}

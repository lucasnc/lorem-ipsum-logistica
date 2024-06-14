import { Component } from '@angular/core';
import { Cliente } from '../../models/cliente';
import { ClienteService } from '../../services/cliente.service';
import { ClienteAddEditComponent } from '../cliente-add-edit/cliente-add-edit.component';
import { CoreService } from '../../core/core.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.css'
})
export class ClienteComponent {

  clientes: Cliente[] = [];
  dataSource: any;
  displayedColumns: string[] = ['id', 'nome', 'dataNascimento', 'genero', 'action'];
  constructor(private clienteService: ClienteService,
    private router: Router,
    private dialog: MatDialog,
    private coreService: CoreService) {}

  ngOnInit() {
    this.getClientes();
  }

  getClientes() {
    this.clienteService.getClientes().subscribe((clientes: Cliente[]) => {
      this.clientes = clientes;
    });
  }

  clienteDetails(id: number) {
      this.router.navigate(['/cliente', id]);
  }

  deleteCliente(id: number, template: any) {
    const dialogRef = this.dialog.open(template, {
      width: '500px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.clienteService.deleteCliente(id).subscribe({
          next: (val: any) => {
            this.coreService.openSnackBar('Cliente excluído com sucesso');
            this.getClientes();
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    });
  }

  openEditForm(data: any) {
    const dialogRef = this.dialog.open(ClienteAddEditComponent, {
      maxWidth: '100vw',
      maxHeight: '100vh',
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getClientes();
        }
      },
    });
  }

  openAddEditClienteForm() {
    const dialogRef = this.dialog.open(ClienteAddEditComponent, {
      maxWidth: '100vw',
      maxHeight: '100vh',
    });
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getClientes();
        }
      },
    });
  }
}

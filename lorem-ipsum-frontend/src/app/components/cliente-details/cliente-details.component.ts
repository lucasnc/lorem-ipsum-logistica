import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ClienteService } from '../../services/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-details',
  templateUrl: './cliente-details.component.html',
  styleUrl: './cliente-details.component.css'
})
export class ClienteDetailsComponent {

  cliente!: Cliente;
  constructor(private route: ActivatedRoute, private clienteService: ClienteService) {

  }
  async ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id');
    await this.clienteService.getCliente(Number(id)).subscribe((cliente: Cliente) => {
      this.cliente = cliente;
    });
  }


}

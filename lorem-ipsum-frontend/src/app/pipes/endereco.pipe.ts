import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  standalone: true,
  name: 'endereco'
})
export class EnderecoPipe implements PipeTransform{
    transform(endereco: number) : string {
        switch (endereco) {
          case 0:
            return 'Residencial';
          case 1:
            return 'Comercial';
          default:
            return '';
        }
    }
}

import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  standalone: true,
  name: 'genero'
})
export class GeneroPipe implements PipeTransform{
    transform(genero: number) : string {
        switch (genero) {
          case 0:
            return 'Masculino';
          case 1:
            return 'Feminino';
          default:
            return '';
        }
    }
}

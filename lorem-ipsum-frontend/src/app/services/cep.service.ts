import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { Endereco } from '../models/endereco';

@Injectable({
  providedIn: 'root'
})
export class CepService {

  apiUrl = 'https://viacep.com.br/ws';

  constructor(private httpClient: HttpClient) { }

  getCep(cep: string): Observable<Endereco> {
    return this.httpClient.get<Endereco>(`${this.apiUrl}/${cep}/json`).pipe();
  }
}

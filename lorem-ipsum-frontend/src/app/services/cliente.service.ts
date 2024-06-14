import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, retry, throwError } from 'rxjs';
import { Cliente } from '../models/cliente';
import { environment } from '../../environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url = `${environment.baseUrl}/cliente`;

  headers = new HttpHeaders({ 'Content-Type': 'application/json' })

  constructor(private httpClient: HttpClient) {

  }

  getClientes(): Observable<Cliente[]> {
    return this.httpClient.get<Cliente[]>(this.url)
      .pipe(
      retry(2),
      catchError(this.handleError))
  }

  getCliente(id: number): Observable<Cliente> {
    return this.httpClient.get<Cliente>(`${this.url}/${id}`)
      .pipe(
      retry(2),
      catchError(this.handleError))
  }

  addCliente(data: any): Observable<any> {
    return this.httpClient.post(this.url, data);
  }

  updateCliente(data: any): Observable<any> {
    return this.httpClient.put(this.url, data);
  }

  deleteCliente(id: number): Observable<any> {
    return this.httpClient.delete(`${this.url}/${id}`);
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}

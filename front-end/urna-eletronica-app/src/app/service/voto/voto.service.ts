import { HttpResponse } from '../../interfaces/http-response';
import { FormVoto } from '../../interfaces/form-voto';
import { environment } from '../../../environments/environment';

import { Observable } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


const API = environment.api;

@Injectable({
  providedIn: 'root'
})
export class VotoService {

  constructor(private httpClient: HttpClient) { }

  votar(formVoto: FormVoto): Observable<HttpResponse> {
    return this.httpClient.post<HttpResponse>(`${API}/vote`, formVoto);
  }

  buscarVotos(): Observable<HttpResponse> {
    return this.httpClient.get<HttpResponse>(`${API}/votes`);
  }
}

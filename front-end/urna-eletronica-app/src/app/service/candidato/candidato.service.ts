import { Candidato } from '../../interfaces/candidato';
import { FormCandidato } from '../../interfaces/form-candidato';
import { HttpResponse } from '../../interfaces/http-response';
import { environment } from '../../../environments/environment';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { first, map, switchMap } from 'rxjs/operators';
import { AbstractControl } from '@angular/forms';

const API = environment.api;

@Injectable({
  providedIn: 'root'
})
export class CandidatoService {

  constructor(private httpClient: HttpClient) { }

  obterCandidato(legenda: number):Observable<HttpResponse> {
    return this.httpClient.get<HttpResponse>(`${API}/candidate/${legenda}`);
  }

  obterTodosCandidatos(): Observable<Candidato[]> {
    return this.httpClient.get<Candidato[]>(`${API}/candidate`);
  }

  salvarCandidato(candidatoForm: FormCandidato): Observable<HttpResponse> {
    return this.httpClient.post<HttpResponse>(`${API}/candidate`, candidatoForm);
  }

  legendaJaExiste() {
    return (control: AbstractControl) => {
      return control.valueChanges.pipe(
        switchMap((legenda: number) =>
           this.obterCandidato(legenda)
        ),
        map((resultado) => {
          resultado ? { legendaExistente: true } : null;
        }
        ),
        first()
      );
    };
  }

  apagarCandidato(id: number): Observable<HttpResponse> {
    return this.httpClient.delete<HttpResponse>(`${API}/candidate/${id}`);
  }
}



import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Candidate } from '../_models/candidate';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {
  private candidates: Candidate[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  
  }

  // GET: Lista de candidatos e votos
  // Difere do método getCandidatos de urna.service.ts em:
  // Não cria uma hash table de retorno
  // Filtra o objeto de candidato especial "Branco"
  async getCandidatos() {
    return (await this.http.get<Candidate[]>(this.baseUrl + 'api/votes')
      .toPromise()
      .catch(error => error)).filter(x => x.legenda != 0);
  }

  // POST: Envia o novo candidato
  async postCandidato(candidato: Candidate) {
    // Enviar voto à API
    return await this.http.post(this.baseUrl + 'api/candidate', candidato, {observe: 'response'})
      .toPromise()
      .catch(error => error);
  }

  // DELETE: Deleta o candidato
  async deleteCandidato(id: number) {
    return await this.http.delete(this.baseUrl + `api/candidate/${id}`, {observe: 'response'})
      .toPromise()
      .catch(error => error);
  }
}

  // Função de validação customizada (Verifica se a legenda está no intervalo correto na hora de cadastrar)
  export function isLegenda(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const forbidden = !(control.value > 0 && control.value < 100);
      return forbidden ? {forbiddenNumber: {value: control.value}} : null;
    };
  }

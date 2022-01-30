import { MensagemService } from './../../service/mensagem/mensagem.service';
import { Candidato } from './../../interfaces/candidato';
import { FormCandidato } from './../../interfaces/form-candidato';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpResponse } from './../../interfaces/http-response';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CandidatoService } from '../../service/candidato/candidato.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  novoCandidatoForm!: FormGroup;
  legendaExistente = false;
  candidatos$ !: Candidato[] ;

  constructor(
    private _formBuilder: FormBuilder,
    private _candidatoService: CandidatoService,
    private _mensagemService : MensagemService
    ) { }

  ngOnInit(): void {
    this.novoCandidatoForm = this._formBuilder.group({
      nomeCompleto: ['', [Validators.required, Validators.minLength(3)]],
      nomeVice: ['', [Validators.required, Validators.minLength(3)]],
      legenda: ['', [
        Validators.required,
        Validators.maxLength(2),
        Validators.min(0),
        Validators.max(99)
      ]]
    });
    this.buscarCandidatos();
  }

  buscarCandidatos(): void  {
    this._candidatoService.obterTodosCandidatos()
      .subscribe((resultado: Candidato[]) => {
        this.candidatos$ = resultado;
    }, (error)=> {
      console.error(error);
      this._mensagemService.mostraMensagem("Não foi possível retornar os dados dos candidatos");
    })
  }

  cadastrar() {
    if(this.novoCandidatoForm.valid) {
      const novoCandidato = this.novoCandidatoForm.getRawValue() as FormCandidato;
      novoCandidato.dataDeRegistro = new Date();
      this._candidatoService.salvarCandidato(novoCandidato).subscribe(
        (resultado: HttpResponse) => {
          this._mensagemService.mostraMensagem(resultado.mensagem);
          this.limpar();
          this.buscarCandidatos();
        }, (error) => {
          console.error(error);
          this._mensagemService.mostraMensagem('Infelizmente não foi possível salvar o candidato ');
        }
      );
    }
  }

  verificarLegenda(value: any) {
    const legenda = Number.parseInt(value);
    this._candidatoService.obterCandidato(legenda).subscribe((resultado: HttpResponse) => {
      if(resultado.dados)
        this.legendaExistente = true;
      else {
        this.legendaExistente = false;
      }
    }, (error) => {
      console.error(error);
      this._mensagemService.mostraMensagem("Infelizmente não foi possível verificar a legenda");
    })
  }


  limpar() {
    this.novoCandidatoForm.get('nomeCompleto')?.setValue('');
    this.novoCandidatoForm.get('nomeVice')?.setValue('');
    this.novoCandidatoForm.get('legenda')?.setValue('');
  }
}

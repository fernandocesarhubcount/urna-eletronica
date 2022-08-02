import { Component, OnInit } from '@angular/core';
import { Candidate } from '../../candidate';
import { VoteService } from '../../services/vote.service';

@Component({
  selector: 'app-primeira-tela',
  templateUrl: './primeira-tela.component.html',
  styleUrls: ['./primeira-tela.component.css']
})
export class PrimeiraTelaComponent implements OnInit {

  numero: number;
  candidato: Candidate = new Candidate();
  nomeCandidato : string;
  nomeVice : string;

  constructor(private voteService: VoteService) { }

  ngOnInit(): void {
    this.loadAllCandidates();
  }

  loadAllCandidates() {  
    this.voteService.getCandidatos();
  } 

  clicou(n : any) {
    let elNumero = document.querySelector<HTMLElement>('.numero.pisca');
    if(elNumero !== null) {
        elNumero.innerHTML = n;
        this.numero = this.numero + n;
        elNumero.classList.remove('pisca');
        if( elNumero.nextElementSibling !== null){
            elNumero.nextElementSibling.classList.add('pisca');
        }
    }
      this.preencherNomesTela();
  } 

  branco() {
    let descricao = document.querySelector<HTMLElement>('.d-1-4');
    let numeros = document.querySelector<HTMLElement>('.d-1-3');

    numeros.innerHTML = '';
    descricao.innerHTML = '<h2>VOTO EM BRANCO</h2>';
    this.numero = 0;
  }

  corrige() {
    window.location.href = 'http://localhost:4200/'
  }

  confirma() {
    let legenda = this.numero;

    if(legenda == undefined){
      return window.alert('Preencha a lengeda ou vote em branco');
    }

    this.voteService.postVoto(String(legenda).replace(undefined,''));

    document.querySelector('.tela').innerHTML = '<h1>FIM</h1>';
  }

  pegarNomes(nomeCandidato: string, nomeVice: string) {
    this.nomeCandidato = nomeCandidato;
    this.nomeVice = nomeVice;
  }

  preencherNomesTela() {
    let legenda = String(this.numero).replace(undefined,'');

    let candidato = this.voteService.getCandidato(Number(legenda));
    
    if (!candidato) {
      this.pegarNomes("CANDIDATO NÃO ENCONTRADO - VOTO NULO", "");
      return;
    }

    this.pegarNomes(candidato.nomeCanditato, candidato.nomeVice);
  }  
}

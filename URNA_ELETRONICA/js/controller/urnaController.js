import Candidato from '../modelo/candidato.js'

class urnaController{
    constructor(){

        this.tecladoNumericoEL = document.querySelectorAll('.botao-numerico')
        this.tecladoNumericoAcoesEL = document.querySelectorAll('.botao-acao')
        this.visorEL = document.querySelector('.visor')
        this.visorConfirmacaoEL = document.querySelector('.visor-confirmacao')
        this.primeiroInputNumericoEl = document.querySelector('.primeiro-digito')
        this.segundoInputNumericoEl = document.querySelector('.segundo-digito')
        this.visorCandidatoEL = document.querySelector('.visorCandidato')
        this.botaoBrancoEL = document.querySelector('.botao-branco')
        this.visorConfirmacaoCandidatoEL = document.querySelector('.visor-confirmacao-candidato')
        
        
        this.criarCandidatos()
        this.observadorTecladoNumerico()
        this.observadorTecladoAcoes()
        
    }

    limparInputs(){
        this.primeiroInputNumericoEl.innerText = ''
        this.segundoInputNumericoEl.innerText = ''
    }
    iniciarProcesso(parametro){
// Segue abaixo código para configurar a função do botão BRANCO  
        if(parametro === "BRANCO"){
            let confirmacao = confirm(`Tem certeza que deseja votar em ${parametro}`)
            
            if (confirmacao) {
                this.visorEL.style.display = 'none'
                this.visorConfirmacaoEL.style.display = 'block'

                setTimeout(() => {
                    this.visorConfirmacaoEL.style.display = 'none'
                    this.visorEL.style.display = 'block'
                }, 4000);

                this.limparInputs()
            }

        }
//Segue abaixo código para configurar a função do botão CORRIGE
        if (parametro === 'CORRIGE'){

            this.visorCandidatoEL.style.display = 'none'

            this.limparInputs()

            this.visorEL.style.display = 'block'

            this.botaoBrancoEL.style.display = 'flex'
        }

// Segue abaixo código para configurar a função do botão CONFIRMAR
        if(parametro === "CONFIRMA"){
            this.visorConfirmacaoCandidatoEL.innerHTML = `
            <div>
                <h1>
                    Obrigado por votar, seu voto para Prefeito de São Paulo foi computado.
                </h1>
            </div>
            `
            
            this.visorEL.style.display ='none'
            this.visorCandidatoEL.style.display = 'none'
            this.visorConfirmacaoCandidatoEL.style.display = 'block'

            setTimeout(() => {
                this.visorConfirmacaoCandidatoEL.style.display = 'none'
                this.visorEL.style.display = 'block'
                this.botaoBrancoEL.style.display = 'flex'
            }, 4000);

                this.limparInputs()


        }
// Segue abaixo codigo para configurar as duas caixas (responsável pela visualização dos números)
        if(typeof(parametro) === 'number') {
            
            let primeiroInput = this.primeiroInputNumericoEl 
            let segundoInput = this.segundoInputNumericoEl

            if( primeiroInput.innerText == "") {
                primeiroInput.innerText = parametro

            } else {
                segundoInput.innerText = parametro

                let votoMontado = Object.assign({}, [this.primeiroInputNumericoEl.innerText, this.segundoInputNumericoEl.innerText])

                

                this.renderizarCandidatos(votoMontado)
            }
        }
    }

    renderizarCandidatos(parametro) {

        let votoComputado = ''
        let candidatosExistentes = this.buscarCandidatos()
        let candidatosVotado = ''


        for (const key in parametro) {
            votoComputado += parametro[key]
        }

        candidatosExistentes.map(candidato => {
            if(candidato.numero == votoComputado){
                candidatosVotado = candidato
            }
        })
        
        this.visorCandidatoEL.innerHTML = `
            <div class= 'titulo-do-visor'>
                 <h1 style = 'width: 70%'>${candidatosVotado.nome}</h1>
                 <img src = ${candidatosVotado.img} style ='width: 20%'></img>
            </div>
            <div>
                <span> Nome do Candidato: ${candidatosVotado.nome}</span>
            </div>
            <div>
                <span> Numero do Candidato: ${candidatosVotado.numero}</span>
            </div>
            <div>
                <span> Partido: ${candidatosVotado.legenda}</span>
            </div>
            <hr>
            <div>
                <span>
                    Aperte a tecla:
                </span>
            </div>
            <div class="orientacao">
                <div>
                    <span>
                        ⚪BRANCO para votar em BRANCO
                    </span>
                </div>
                <div>
                    <span>
                        🟠LARANJA para CORRIGIR
                    </span>
                </div>
                <div>
                    <span>
                        🟢VERDE para CONFIRMAR
                    </span>
                </div>
            </div>

        `
        this.visorEL.style.display = 'none'
        this.visorCandidatoEL.style.display = 'block'
        this.botaoBrancoEL.style.display = 'none'
    }

    observadorTecladoNumerico(){

        this.tecladoNumericoEL.forEach(botao => {
            botao.addEventListener('click', e => {
                let parametroNumerico = Number(e.target.innerText)

                this.iniciarProcesso(parametroNumerico)
            })
        })
    }
    observadorTecladoAcoes(){

        this.tecladoNumericoAcoesEL.forEach(botao => {
            botao.addEventListener('click', e => {
                let parametro = e.target.innerText
                this.iniciarProcesso(parametro)
            })
        })
    }
// Abaixo foi criando uma lista de candidatos
    criarCandidatos(){

        let candidatos = [
            new Candidato('Fernando Haddad', 'PT', '15', '../../imagens/fernando_haddad.png'),
            new Candidato('Tarcísio de Freitas', 'REP', '26', '../../imagens/tarcisio_freitas.png'),
            new Candidato('Gabriel Colombo', 'PCB', '37', '../../imagens/gabriel.png'),
            new Candidato('Márcio França', 'PSB', '48', '../../imagens/marcio_franca.png')
        ]

        localStorage.setItem('candidatos', JSON.stringify(candidatos))

    } 

    buscarCandidatos(){
        let candidatosBuscados = JSON.parse(localStorage.getItem('candidatos'))  

        return candidatosBuscados
    }
}

window.App = new urnaController()
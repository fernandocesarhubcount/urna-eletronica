<template>
  <v-container>
    <v-row>
      <v-col>
        <v-card height="500" style="background-color: #f0f8ff">
          <v-card-text>
            <v-row>
              <v-col>
                <v-card height="400">
                  <v-card-text>
                    <!-- TELA VOTAÇÃO !-->
                    <div v-if="Aguarda == true ">
                      <v-row>
                        <v-col>
                          <div class="text-center">
                            <v-progress-circular
                              :size="50"
                              color="primary"
                              indeterminate
                            ></v-progress-circular>
                          </div>
                        </v-col>
                        <v-col>
                          <h3>Aguardar Processamento!</h3>
                        </v-col>
                      </v-row>
                    </div>
                    <!-- TELA FIM !-->
                    <div v-if="Fim == true">
                      <v-row>
                        <v-col>
                          <div>
                            <h1>FIM</h1>
                          </div>
                        </v-col>
                      </v-row>
                    </div>
                    <!-- TELA VOTACÃO !-->
                    <div v-if="Detalhe != true">
                      <v-row>
                        <h1>PREFEITO(A)</h1>
                      </v-row>
                      <v-row align="center">
                        <v-col md="2">
                          <v-text-field
                            class="centered-input text--darken-3 mt-3"
                            v-model="vModel_Campo1"
                            disabled
                            solo
                          ></v-text-field>
                        </v-col>
                        <v-col md="2">
                          <v-text-field
                            class="centered-input text--darken-3 mt-3"
                            v-model="vModel_Campo2"
                            disabled
                            solo
                          ></v-text-field>
                        </v-col>
                      </v-row>
                    </div>
                    <!-- TELA DETALHE CANDIDATO !-->
                    <div
                      v-if="Detalhe == true && Aguarda == false && Fim == false "
                    >
                      <v-row>
                        <h1>SEU VOTO PARA: PREFEITO</h1>
                      </v-row>
                      <div class="t1">
                        <v-row>
                          <v-col cols="2">
                            <h3 style="text-align: left">Número:</h3>
                          </v-col>
                          <v-col cols="2">
                            <v-text-field
                              class="centered-input text--darken-3 mt-3 shrink"
                              v-model="vModel_Campo1"
                              disabled
                              solo
                            ></v-text-field>
                          </v-col>
                          <v-col cols="2">
                            <v-text-field
                              class="centered-input text--darken-3 mt-3 shrink"
                              v-model="vModel_Campo2"
                              disabled
                              solo
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <div v-if="vCandidato.item == null && vBranco == false">
                          <v-row>
                            <v-col>
                              <h1 style="text-align: CENTER">VOTO NULO</h1>
                            </v-col>
                          </v-row>
                        </div>
                        <div v-else-if="vBranco == true">
                          <v-row>
                            <v-col>
                              <h1 style="text-align: CENTER">VOTO BRANCO</h1>
                            </v-col>
                          </v-row>
                        </div>
                        <div v-else>
                          <v-row>
                            <v-col cols="3">
                              <h3 style="text-align: left">Prefeito</h3>
                            </v-col>
                            <v-col cols="9">
                              <h3 style="text-align: left">
                                {{this.vNomePrefeito}}
                              </h3>
                            </v-col>
                          </v-row>

                          <v-row>
                            <v-col cols="3">
                              <h3 style="text-align: left">Vice-Prefeito</h3>
                            </v-col>
                            <v-col cols="9">
                              <h3 style="text-align: left">
                                {{this.vNomeVicePrefeito}}
                              </h3>
                            </v-col>
                          </v-row>
                          <v-row>
                            <v-col cols="3">
                              <h3 style="text-align: left">Legenda</h3>
                            </v-col>
                            <v-col cols="4">
                              <h3 style="text-align: left">
                                {{this.vLegenda}}
                              </h3>
                            </v-col>
                          </v-row>
                        </div>
                      </div>
                      <v-row style="margin-top: 60px">
                        <v-divider />
                      </v-row>
                      <v-row>
                        <h4 style="text-align: left">Aperte a tecla:</h4>
                      </v-row>
                      <v-row> CONFIRMA para CONFIRMAR este voto </v-row>
                      <v-row> CORRIGE para REINICIAR este voto </v-row>
                    </div>
                  </v-card-text>
                </v-card>
              </v-col>
              <v-col cols="5">
                <v-card dark>
                  <v-card-text>
                    <v-row>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(1)"> 1 </v-btn>
                      </v-col>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(2)"> 2 </v-btn>
                      </v-col>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(3)"> 3 </v-btn>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(4)"> 4 </v-btn>
                      </v-col>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(5)"> 5 </v-btn>
                      </v-col>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(6)"> 6 </v-btn>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(7)"> 7 </v-btn>
                      </v-col>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(8)"> 8 </v-btn>
                      </v-col>
                      <v-col cols="4">
                        <v-btn @click="NumeroClicado(9)"> 9 </v-btn>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col>
                        <v-btn @click="NumeroClicado(0)"> 0 </v-btn>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col>
                        <v-btn
                          style="color: black; background-color: white"
                          @click="Branco()"
                        >
                          Branco
                        </v-btn>
                      </v-col>
                      <v-col>
                        <v-btn
                          style="color: black; background-color: OrangeRed"
                          @click="Corrige()"
                        >
                          Corrige
                        </v-btn>
                      </v-col>
                      <v-col>
                        <v-btn
                          style="color: black; background-color: green"
                          @click="Confirma()"
                        >
                          confirma
                        </v-btn>
                      </v-col>
                    </v-row>
                  </v-card-text>
                </v-card>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data () {
    return {
     vModel_Campo1: String,
     vModel_Campo2: String,
     vNomePrefeito: "",
     vNomeVicePrefeito: "",
     vLegenda: Number,
     Aguarda: false,
     Detalhe: false,
     Fim: false,
     vBranco: false,
     vCandidato : []
    }
  },
  mounted() {
    // ZERA AS VARIAVEIS PARA NOVA VOTAÇÃO
    this.Corrige()
  },
  methods: {
    NumeroClicado(NumeroClicado){

      if(!isNaN(NumeroClicado)){
        if(this.vModel_Campo1 === ''){

          this.vModel_Campo1 = NumeroClicado
          return
        }
        if(this.vModel_Campo2 === ''){

          this.vModel_Campo2 = NumeroClicado
          this.Detalhe = true;
          this.BuscaCandidato()
          return
        }
      }
      return
    },
    async BuscaCandidato(){

      this.Aguarda = true;
      let legenda =  parseInt(this.vModel_Campo1 + '' + this.vModel_Campo2)

      await  this.axios.get(`https://localhost:44322/Urna/candidate?Legenda=${legenda}`).then((response) => {

        this.vCandidato = response.data

        if(response.data.item != null){
          this.vNomePrefeito = response.data.item.nome_Completo
          this.vNomeVicePrefeito = response.data.item.nome_Vice
          this.vLegenda = response.data.item.legenda
        }
      })
      this.Aguarda = false;
    },
    Branco(){
      this.Corrige();
      this.vModel_Campo1 = ' ',
      this.vModel_Campo2 = ' ',
      this.Detalhe = true,
      this.vBranco = true
    },
    Corrige(){
      this.vModel_Campo1 = '',
      this.vModel_Campo2 = '',
      this.vNomePrefeito = '',
      this.vNomeVicePrefeito = ''
      this.vBranco = false
      this.Aguarda = false
      this.Fim = false
      this.Detalhe = false
    },

    async Confirma(){

      // VERIFICA SE ESTÁ SOMENTE-SE EM  DETALHES DO CANDIDATO
      if(this.Detalhe !== false && this.Fim == false){
        this.Aguarda = true;
        let voto = [];

        voto = { ID_Voto : 0,
                 ID_Candidato : this.vCandidato.item != null ? this.vCandidato.item.iD_Candidato : null ,
                 Data_do_Voto : new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000).toISOString() }


        await this.axios.post(`https://localhost:44322/Urna/vote`,voto)
        this.Aguarda = false;
        this.Fim = true;
      }
    }
  }
}
</script>

<style scoped>
.t1 {
  margin-top: 30px;
}
.centered-input >>> input {
  text-align: center;
}
</style>

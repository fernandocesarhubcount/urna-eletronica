<template>
  <v-container>

    <v-overlay v-model="Aguarda">
      <v-progress-circular
        indeterminate
        size="64"
      ></v-progress-circular>
    </v-overlay>

    <v-snackbar v-model="snackbar" :color="snackbarColor" top>
      {{ snackbarText }}
      <template v-slot:action="{ attrs }">
        <v-btn color="black" text v-bind="attrs" @click="snackbar = false">
          Fechar
        </v-btn>
      </template>
    </v-snackbar>
  <v-row>
    <v-col>
    <v-card>
      <v-card-text>
        <div>
          <v-form ref="form" v-model="valid" lazy-validation>
            <v-text-field
              required
              :rules="nameRules"
              v-model="vNomePrefeito"
              label="Nome Prefeito"
            ></v-text-field>
            <v-text-field
              required
              :rules="nameRules"
              v-model="vNomeVice"
              label="Nome Vice-Prefeito"
            ></v-text-field>
            <v-text-field
              required
              type="number"
              v-model="vNumeroLegenda"
              :rules="legendaRules"
              label="Legenda"
            ></v-text-field>

            <v-btn
              :disabled="!valid"
              color="success"
              class="mr-4"
              @click="validate"
            >
              Cadastrar
            </v-btn>
          </v-form>
        </div>
      </v-card-text>
    </v-card>
    </v-col>
  </v-row>
  <v-row>
   <v-col>
    <v-card>
      <v-card-text>
                <v-combobox
                  dense
                  outlined
                  label="Candidato"
                  v-model="vCandidatoModel"
                  :items="vCandidatoItems"
                  :item-text="item => 'ID:'+ item.iD_Candidato + ' Legenda:' +  item.legenda+ ' Nome Prefeiro: ' + item.nome_Completo + ' Vice Prefeito: ' + item.nome_Vice + ' Data Registro: ' +item.data_Registro  "
                  persistent-hint
                  @change="CandidatoChanged()"
                  @click="buscarCandidatos()"
                ></v-combobox>
            <v-btn v-if="AtivaApagar == true"
              color="error"
              @click="Apagar()"
            >
              Apagar
            </v-btn>
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

      vNumeroLegenda: Number,
      vCandidatoItems: [],
      snackbar: false,
      Aguarda: false,
      AtivaApagar: false,
      snackbarText : "",
      snackbarColor: "",
      vNomeVice: "",
      vNomePrefeito: "",
      valid: true,
      nameRules: [
        v => !!v || 'Campo requerido',
      ],
      legendaRules: [
          v  => {
          if (!isNaN(parseFloat(v)) && v >= 0 && v <= 99) return true;
          return 'Fora do intervalo [0-99]';
          }
      ]
    }

  },
mounted() {
  this.buscarCandidatos()
  console.log(this.vCandidatoModel);
  console.log(this.vCandidatoItems);

},

  methods: {
    validate () {
      if(this.$refs.form.validate() == true){
        this.cadastraCandidato()
      }
      else {
        return false
      }
    },

    snackbarHelper(snackbar,snackbarText,snackbarColor){
              this.snackbar = snackbar
              this.snackbarText = snackbarText
              this.snackbarColor = snackbarColor
    },

    update(){
      this.$router.push('cadastro-candidato')
    },

    async Apagar(){

      this.Aguarda = true;
      await this.axios.delete(`https://localhost:44322/Urna/candidate?ID_Candidato=${this.vCandidatoModel.iD_Candidato}`).then((response) => {

          if(response.data.erro == true){
            this.snackbarHelper(true,response.data.msg,"red")
          }
          else{
            this.snackbarHelper(true,response.data.msg,"green")
          }
      })

    this.Aguarda = false;
    this.buscarCandidatos()

    },
    async buscarCandidatos(){

          await  this.axios.get(`https://localhost:44322/Urna/candidate`).then((response) => {
              this.vCandidatoItems = response.data.item

            if(response.data.erro == true){
              this.snackbarHelper(true,response.data.msg,"red")
            }
          })


    },
    CandidatoChanged(){


      this.AtivaApagar = true;
    },
    async cadastraCandidato(){
      this.Aguarda = true;
      try{
        let candidato =   {
                            ID_Candidato : 0,
                            nome_Completo: this.vNomePrefeito,
                            nome_Vice: this.vNomeVice,
                            data_Registro : new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000).toISOString(),
                            legenda: this.vNumeroLegenda
                          }

          await  this.axios.post(`https://localhost:44322/Urna/candidate`,candidato).then((response) => {

            if(response.data.erro == true){
              this.snackbarHelper(true,response.data.msg,"red")
            }
            else{
              this.snackbarHelper(true,response.data.msg,"green")
            }
          })
        this.Aguarda = false;
        this.buscarCandidatos()

      } catch(E){
        this.Aguarda = false;
      }
    }
  },
}
</script>

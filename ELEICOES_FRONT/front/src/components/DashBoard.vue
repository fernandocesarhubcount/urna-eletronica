<template>
  <v-container>
    <v-data-table
      :headers="headers"
      :items="items"
    >
    </v-data-table>
  </v-container>
</template>

<script>
  export default {
    data () {
      return {
        headers: [
          {
            text: 'Legenda',
            align: 'start',
            sortable: true,
            value: 'legenda',
          },
          { text: 'Votos', value: 'qtde_Votos',sortable: true,},
          { text: 'Prefeito', value: 'nome_Prefeito' },
          { text: 'Vice-Prefeito', value: 'nome_VicePrefeito' },
        ],
        items: [],
      }
    },
  mounted() {
    this.carregaVotos()
  },

    methods: {
        async carregaVotos(){
            await  this.axios.get(`https://localhost:44322/Urna/vote`).then((response) => {
                this.items = response.data.item;
            })
        }
    },
  }
</script>

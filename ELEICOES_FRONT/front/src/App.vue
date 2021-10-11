<template>
  <v-app>

    <!-- <DashBoard/> -->
    <!-- <UrnaEletronica/> -->
    <router-view/>

  </v-app>
</template>

<script>
// import UrnaEletronica from './components/UrnaEletronica.vue'
// import DashBoard from './components/DashBoard.vue'
// import MenuComponent from './components/menu.vue'

// import CadastroCandidato from './components/CadastroCandidato.vue'

export default {
  name: 'App',
  components: {
    // DashBoard,
    // MenuComponent,
    // UrnaEletronica,
    // CadastroCandidato
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, Ar sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  height: 1000px;
  background: -webkit-linear-gradient(to right, #7c7c7c, #797273, #9f9ea1);
  background: linear-gradient(to right, #797273, #353434, #7c7c7c);

}
</style>

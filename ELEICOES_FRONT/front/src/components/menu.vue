<template>
  <v-container>
    <v-row>
                      <router-view />
      <v-col>
            <v-btn
              color="error"
              @click="$router.push('cadastro-candidato')"
            >
              Cadastro Candidatos
            </v-btn>
     </v-col>
      <v-col>
            <v-btn
              color="error"
              @click="$router.push('urna-eletronica')"
            >
              Urna Eletronica
            </v-btn>
      </v-col>
      <v-col>
            <v-btn
              color="error"
              @click="$router.push('dashboard')"
            >
              DASHBOARD
            </v-btn>
      </v-col>

    </v-row>
  </v-container>
</template>

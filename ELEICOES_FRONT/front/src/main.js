import Vue from 'vue'
import App from './App.vue'
import vuetify from '@/plugins/vuetify' // path to vuetify export
import axios from 'axios'
import router from './router'
import VueAxios from 'vue-axios'
    router,

Vue.config.productionTip = false
Vue.use(VueAxios, axios)

new Vue({
  vuetify,
  router,
  render: h => h(App),
}).$mount('#app')

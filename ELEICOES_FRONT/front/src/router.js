import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
    mode: 'hash',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            redirect: 'urna-eletronica',
            component: () => import('@/components/menu'),
            children: [
                {
                    name: 'CadastroCandidato',
                    path: 'cadastro-candidato',
                    component: () => import('@/components/CadastroCandidato'),
                },
                {
                    name: 'DashBoard',
                    path: 'dashboard',
                    component: () => import('@/components/DashBoard'),
                },
                {
                    name: 'UrnaEletronica',
                    path: 'urna-eletronica',
                    component: () => import('@/components/UrnaEletronica'),
                },

            ]
        },

    ],
})
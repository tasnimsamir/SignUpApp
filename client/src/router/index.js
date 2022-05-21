import Vue from 'vue'
import VueRouter from 'vue-router'
import RegisterView from '../views/RegisterView.vue'
import UserView from '../views/UserView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'register',
    component: RegisterView,
  },
  {
    path: '/user/:id',
    name: 'user',
    component: UserView,
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

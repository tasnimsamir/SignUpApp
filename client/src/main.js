import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import axios from "axios"
import store from './store'

Vue.config.productionTip = false
axios.defaults.baseURL = "https://localhost:44365/"

new Vue({
  vuetify,
  router,
  store,
  render: h => h(App)
}).$mount('#app')
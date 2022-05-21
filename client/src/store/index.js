import Vuex from 'vuex';
import Vue from 'vue';
import createPersistedState from "vuex-persistedstate";
import register from './modules/register';

// Load Vuex
Vue.use(Vuex);
// Create store
export default new Vuex.Store({
  modules: {
    register
  },
  plugins: [createPersistedState()]
});
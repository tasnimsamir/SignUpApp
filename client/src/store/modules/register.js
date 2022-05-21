import axios from "axios";

const state = {

    user:{'id':'',
          'firstname': '',
          'fathername':'',
          'familyname':'',
          'username':'',
          'birthdate': '',
          'address':'',
          'occupation':'',
    },

};

const getters = {
    StateUser: (state) => state.user,
};

const actions = {
    async Register({commit}, form) {
      let response = await axios.post('api/Users', form)
      await commit('setUser',response.data)
    },
};

const mutations = {
    setUser(state, user) {
      state.user = user;
    },
}


export default{
    state,
    getters,
    actions,
    mutations
}
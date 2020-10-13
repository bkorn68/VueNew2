
import Vue from 'vue';
import Vuex from 'vuex';
import Axios from 'axios';
import createPersistedState from 'vuex-persistedstate';

Vue.use(Vuex);

const getDefaultState = () => {
  return {
    ident: '',
    token: '',
    mandatorId: 1,
    environment: 1,
    isLoggedIn: false

  };
};

export default new Vuex.Store({
  strict: true,
  plugins: [createPersistedState()],
  state: getDefaultState(),
  getters: {
    isLoggedIn: state => {
      return state.isLoggedIn;
    },
    getIdent: state => {
      return state.ident;
    },
    getMandatorId: state => {
      return state.mandatorId;
    },
    getEnvironment: state => {
      return state.environment;
    }
  },
  mutations: {
    SET_ISLOGGEDIN: (state, isLoggedIn) => {
      state.isLoggedIn = isLoggedIn;
      console.log("isLoggedIn stored");

    },
    SET_IDENT: (state, ident) => {
      state.ident = ident;
      console.log("ident stored");

    },
    SET_TOKEN: (state, token) => {
      state.token = token;
      console.log("token stored");
    },
    SET_MANDATORID: (state, mandatorId) => {
      state.mandatorId = mandatorId;
      console.log("mandatorId stored");
    },
    SET_ENVIRONMENT: (state, environment) => {
      state.environment = environment;
      console.log("environment stored");
    },
    RESET: state => {
      Object.assign(state, getDefaultState());
    }
  },
  actions: {
    login: ({ commit, dispatch }, { ident, token, mandatorId, environment }) => {
      
      commit('SET_ISLOGGEDIN', (ident));
      commit('SET_IDENT', ident);
      commit('SET_TOKEN', token);
      commit('SET_MANDATORID', mandatorId);
      commit('SET_ENVIRONMENT', environment);

      // set auth header
      Axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    },
    logout: ({ commit }) => {
      commit('RESET', '');
    },
    resetstore: ({ commit }) => {
      commit('RESET', '');
    }
  }
  }
);
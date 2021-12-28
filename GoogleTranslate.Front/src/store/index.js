import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    src: '',
    tgt: '',
  },
  mutations: {
    setSrc(state, src) {
      state.src = src
    },
    setTgt(state, tgt) {
      state.tgt = tgt
    }    
  },

  actions: {
  },
  modules: {
  }
})

import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    src: '',
    tgt: '',
    textSrc: '',
    textTgt: '',
    url: 'https://localhost:44034/api',
    error: ''
  },
  mutations: {
    setSrc(state, src) {
      state.src = src
    },
    setTgt(state, tgt) {
      state.tgt = tgt
    },
    setSrcText(state, text) {
      state.textSrc = text
    },
    setTgtText(state, text) {
      state.textTgt = text
    }, 
    setError(state, text) {
      state.error = text
    },      
  },

  actions: {
    translate(context){
      let api = this.state.url + '/Translation'
      let json = {
        source : this.state.src,
        target : this.state.tgt,
        text : this.state.textSrc
      }
      axios.post(api, json, { headers : { 'Content-Type' : 'application/json'} } )
      .then( (response) => {
        context.commit('setTgtText', response.data.translations[0])
        if (response.data.error.message !== null)
          context.commit('setError', response.data.error.message)
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })
    }
  },
  modules: {
  }
})

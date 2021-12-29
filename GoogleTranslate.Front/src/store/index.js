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
    url: 'https://localhost:44304/api'
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
      })
      .catch( (error) => {
        console.log(error)
      })
    }
  },
  modules: {
  }
})

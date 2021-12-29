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
      // let api = 'https://hookb.in/ggDB003yqaFG7Voo7oLX'
      try {
        let json = {
          source : this.state.src,
          target : this.state.tgt,
          text : this.state.textSrc
        }
        console.log("json: " + JSON.stringify(json))
        axios.post(api, json, { headers : { 'Content-Type' : 'application/json'} } )
        .then( (response) => {
          console.log(response)
          context.commit('setTgtText', response.data.translations[0])
        })
        .catch( (error) => {
          console.log(error)
        })
        // console.log("result.data: " + response)
        // context.commit()
      }
      catch(e) {
        console.log("Error: " + e.message)
      }
    }
  },
  modules: {
  }
})

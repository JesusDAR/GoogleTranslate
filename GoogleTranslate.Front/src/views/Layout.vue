<template>
  <v-container>
    <v-row>
        <v-col cols="12">
          <v-row>
            <v-col cols="6">
                <layout-button @click.native="setSrc(en)" text="English" :color="$store.state.src === en ? 'success' : 'normal'"/>
                <layout-button @click.native="setSrc(fr)" text="Français" :color="$store.state.src === fr ? 'success' : 'normal'"/>
                <layout-button @click.native="setSrc(de)" text="Deutsch" :color="$store.state.src === de ? 'success' : 'normal'"/>
            </v-col>
            <v-col cols="6">
                <layout-button @click.native="setTgt(en)" text="English" :color="$store.state.tgt === en ? 'success' : 'normal'" :disabled="$store.state.src === en"/>
                <layout-button @click.native="setTgt(fr)" text="Français" :color="$store.state.tgt === fr ? 'success' : 'normal'" :disabled="$store.state.src === fr"/>
                <layout-button @click.native="setTgt(de)" text="Deutsch" :color="$store.state.tgt === de ? 'success' : 'normal'" :disabled="$store.state.src === de"/>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="6">
              <layout-text-area label="Source" outlined />
            </v-col>
            <v-col cols="6">
              <layout-text-area label="Target" color="grey lighten-5" filled disabled/>
            </v-col>
          </v-row>
          <v-row class="text-center">
            <v-col cols="12">
              <layout-button @click="translate" color="primary" :text="btnText" :disabled="$store.state.src === '' || $store.state.tgt === ''"/>
            </v-col>
          </v-row>
        </v-col>
    </v-row>
  </v-container>
</template>

<script>
  import LayoutTextArea from '@/components/LayoutTextArea'
  import LayoutButton from '@/components/LayoutButton'

  export default {
    name: 'Layout',
    components: {
        LayoutButton,
        LayoutTextArea
    },
    data() {
      return {
        en: 'en',
        fr: 'fr',
        de: 'de',
        translateText: ["Translate","Traduire","Übersetzen"],
      }
    },
    created() {
      this.btnText
    },
    computed: {
      btnText: function() {
        console.log(this.$store.state.tgt)
        if(this.$store.state.tgt === this.en) { return this.translateText[0]}
        if(this.$store.state.tgt === this.fr) { return this.translateText[1]}
        if(this.$store.state.tgt === this.de) { return this.translateText[2]}
        return this.translateText[0]
      }
    },
    methods: {
      translate(){
        console.log("translate")
      },
      setSrc(src) {
        // console.log("Hola")
        this.$store.commit('setSrc',src)
        // console.log(this.$store.state.src)
      },
      setTgt(tgt) {
        this.$store.commit('setTgt',tgt)
        // console.log(this.$store.state.tgt)
      },      
    }
  }
</script>

<template>
  <v-container>
    <v-row>
        <v-col cols="12">
          <v-row>
            <v-col cols="6">
                <layout-button text="English"/>
                <layout-button text="Français"/>
                <layout-button text="Deutsch"/>
            </v-col>
            <v-col cols="6">
                <layout-button text="English"/>
                <layout-button text="Français"/>
                <layout-button text="Deutsch"/>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="6">
              <layout-text-area label="Source" disabled="false"/>
            </v-col>
            <v-col cols="6">
              <layout-text-area label="Target" disabled="true"/>
            </v-col>
          </v-row>
        </v-col>
    </v-row>
    <!-- <hello-world /> -->
  </v-container>
</template>

<script>
  // import HelloWorld from '@/components/HelloWorld'
  import LayoutTextArea from '@/components/LayoutTextArea'
  import LayoutButton from '@/components/LayoutButton'

  export default {
    name: 'Layout',

    components: {
      // HelloWorld,
      LayoutButton,
      LayoutTextArea
    },
  }
</script>

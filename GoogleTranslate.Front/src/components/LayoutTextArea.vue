<template>
    <v-container>
          <v-textarea
          outlined
          :label="label"
          hint=""
          rows="10"
          @input="emitToParent($event)"
          v-model="text"
          :disabled="disabled"
          :background-color="color"
        ></v-textarea>
    </v-container>
</template>

<script>
export default {
    name: "LayoutTextArea",
    data() {
        return {
            text : ''
        }
    },
    props: {
        text: String,
        label: String,
        disabled: Boolean,
        color: String
    },
    methods: {
        emitToParent (event) {
            this.$emit('input', this.text)
        }
    }
}
</script>

<style>

</style>
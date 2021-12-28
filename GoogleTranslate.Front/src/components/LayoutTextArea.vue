<template>
    <v-container>
          <v-textarea
          outlined
          :label="label"
          value=""
          hint=""
          rows="10"
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
        }
    },
    props: {
        label: String,
        disabled: Boolean,
        color: String
    }
}
</script>

<style>

</style>
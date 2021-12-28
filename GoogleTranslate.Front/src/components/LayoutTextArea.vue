<template>
    <v-container>
          <v-textarea
          outlined
          :label="label"
          value=""
          hint=""
          rows="10"
          :disabled="disabled"
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
    props: [
        'label',
        'disabled'
    ]
}
</script>

<style>

</style>
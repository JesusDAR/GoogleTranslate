<template>
    <v-btn class="mx-2" :color="color" :disabled="disabled" large>{{ text }}</v-btn>
</template>

<script>
export default {
    name: "LayoutButton",
    data() {
        return {
        }
    },
    props: {
        text: String,
        color: String,
        disabled: Boolean
    },
}
</script>

<style>
</style>
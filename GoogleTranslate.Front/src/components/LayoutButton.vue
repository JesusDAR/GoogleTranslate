<template>
    <v-btn class="mx-2" large>{{ text }}</v-btn>
</template>

<script>
export default {
    name: "LayoutButton",
    data() {
        return {
        }
    },
    props: [
        'text'
    ]
    
}
</script>

<style>
</style>
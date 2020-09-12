<template>
    <div class="pt-5 container">
        <h1  class="center">Welcome to Items catalog</h1>
        <a class="btn btn-primary center" @click="openItems()">Begin</a>
    </div>
</template>

<style>
.center {
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>

<script>
export default {
    methods: {
        openItems(){
            this.$router.push('/items'); 
        }
    }
}
</script>
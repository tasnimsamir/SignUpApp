<template>
<v-app>
  <div id="app">
    <router-view/>
  </div>
</v-app>
</template>

<style lang="scss">
.data--required label::before {
    content: "* " !important;
    color: red !important;
  }
</style>
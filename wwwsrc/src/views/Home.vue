<template>
  <div class="home">
    <h1>Welcome Home</h1>

    <div class="container">
      <div class="card-columns">
        <!-- NOTE is where cards will go -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

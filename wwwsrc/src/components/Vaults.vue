<template>
  <div class="vault">
    <h2 class="name">{{ vaultData.name }}</h2>
    <div class="description">{{ vaultData.description }}</div>
    <form @submit.prevent="addKeep">
      <input type="text" placeholder="name" v-model="newKeep.name" required />
      <button type="submit">Create Keep</button>
    </form>
    <br />
    <div class="row" style="padding: 0rem 3rem">
      <div v-for="keep in keeps" :key="keep._id">
        <Keep :keepData="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/keep";
export default {
  name: "vaults",
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", vaultData.id);
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  props: ["vaultData"]
};
</script>

<style></style>

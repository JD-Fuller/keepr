<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12" style="flex-wrap: wrap">
        <div class="card" style="border: .1rem solid lightgrey;">
          <h3 class="card-header name">{{ activeVault.name }}</h3>
          <h5 class="description">{{ activeVault.description }}</h5>
          <br />
          <div class="row">
            <div class="col-md-12 card-columns" style="flex-wrap: wrap;">
              <div v-for="vKeep in vaultKeeps" :key="vKeep._id">
                <keep-component :keepData="vKeep" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import KeepComponent from "../components/keep";
export default {
  name: "vault",
  mounted() {
    // this.$store.dispatch("setActiveVault", vaultData.id);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
    // keeps() {
    //   return this.$store.state.privateKeeps;
    // },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  components: {
    KeepComponent
  },
  props: ["vaultData"]
};
</script>

<style></style>

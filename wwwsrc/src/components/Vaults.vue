<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12" style="flex-wrap: wrap">
        <div class="card" style="border: .1rem solid lightgrey;">
          <h3 class="card-header name">{{ activeVault.name }}</h3>
          <button
            class="border-0 float-right"
            @click="deleteVault(activeVault.id)"
          >
            <i
              class="far fa-minus-square align-self-end"
              v-if="$auth.isAuthenticated"
            ></i>
          </button>

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
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
  },
  methods: {
    deleteVault(vaultId) {
      debugger;
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    },
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

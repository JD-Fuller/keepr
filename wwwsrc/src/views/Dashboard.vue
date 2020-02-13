<template>
  <div class="dashboard">
    <h1
      style="text-align: center; font-family: montserrat; font-variant: all-small-caps; font-size: 5rem;"
    >
      Vault of the Vaults
    </h1>
    <div class="row" style="justify-content: space-between;">
      <div class="col-8">
        <!--SECTION CREATE VAULT SECTION-->
        <h2>Vault Creator 3000</h2>
        <form @submit.prevent="createVault">
          <input
            type="text"
            placeholder="name"
            v-model="newVault.name"
            required
          />
          <input
            type="text"
            placeholder="description"
            v-model="newVault.description"
          />
          <button type="submit">Create Vault</button>
        </form>
      </div>
      <!--SECTION SELECT VAULT SECTION-->
      <div class="col-4 align-self-end">
        <h2>Vault Selector 3000</h2>
        <select
          class="form-control"
          @change="setActiveVault($event)"
          v-if="$auth.isAuthenticated"
        >
          <option value selected disabled>Select Vault</option>
          <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{
            vault.name
          }}</option>
        </select>
      </div>
      <div class="col-12">
        <h2 style="text-align: center;">{{ activeVault.name }}</h2>
        <!--NOTE Vault Component -->
        <vault-component />
      </div>
    </div>
  </div>
</template>

<script>
import VaultComponent from "../components/vaults";
export default {
  name: "dashboard",
  data() {
    return {
      newVault: {
        name: "",
        description: "",
        isPrivate: false,
        views: 0,
        shares: 0,
        keeps: 0
      }
    };
  },
  mounted() {
    debugger;
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getKeepsByVaultId", this.activeVaultId);
    this.$store.dispatch("getActiveVault");
  },
  methods: {
    setActiveVault(event) {
      this.activeVaultId =
        event.target.options[event.target.options.selectedIndex].value;
      this.$store.dispatch("setActiveVault", this.activeVaultId);
      this.$store.dispatch("getKeepsByVaultId", this.activeVaultId);
    },
    createVault() {
      let vault = { ...this.newVault };
      this.$store.dispatch("createVault", vault);
      this.newVault = {
        name: "",
        description: "",
        isPrivate: false,
        views: 0,
        shares: 0,
        keeps: 0
      };
    },
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  computed: {
    activeVault() {
      return this.$store.state.activeVault;
    },
    vaults() {
      debugger;
      return this.$store.state.vaults;
    }
  },
  components: {
    VaultComponent
  }
};
</script>

<style></style>

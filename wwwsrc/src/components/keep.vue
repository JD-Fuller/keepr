<template>
  <div class="card m-3 rounded-lg" style="max-width: 250px">
    <img
      class="card-img-top rounded-top"
      :src="keepData.img"
      alt="Card image cap"
    />
    <div class="card-body">
      <h4 class="card-title">{{ keepData.name }}</h4>
      <p class="card-text">
        {{ keepData.description }}
      </p>
      <select
        class="form-control"
        @change="addVaultKeep($event, keepData.id)"
        v-if="$auth.isAuthenticated"
      >
        <option value selected disabled>Select Vault</option>
        <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{
          vault.name
        }}</option>
      </select>

      <button
        class="border-0 float-right"
        @click="deleteKeep(keepData.id)"
        v-if="this.keepData.userId == this.$auth.user.sub"
      >
        <i class="fas fa-times-circle" v-if="$auth.isAuthenticated"></i>
      </button>

      <button
        class="border-0 float-right"
        @click="deleteVaultKeep(keepData.id)"
        v-if="this.$route.name == 'dashboard'"
      >
        <i class="fas fa-times-circle" v-if="$auth.isAuthenticated"></i>
      </button>
      <p class="card-text">
        <small class="text-muted"
          ><i class="fas fa-eye"></i>{{ keepData.views
          }}<i class="far fa-user"></i>{{ keepData.keeps
          }}<i class="fas fa-calendar-alt"></i>{{ keepData.shares }}</small
        >
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  methods: {
    addVaultKeep(event, keepId) {
      let vaultId = parseInt(event.target.value);
      let vaultKeep = { vaultId, keepId };
      this.$store.dispatch("addVaultKeep", vaultKeep);
    },
    deleteVaultKeep(keepId) {
      debugger;
      let vaultKeep = {};
      let vaultId = this.activeVault.id;
      vaultKeep = { vaultId, keepId };
      this.$store.dispatch("deleteVaultKeep", vaultKeep);
    },
    deleteKeep(keepId) {
      debugger;
      let vaultKeep = {};
      let vaultId = this.activeVault.id;
      vaultKeep = { vaultId, keepId };
      this.$store.dispatch("deleteKeep", vaultKeep);
    }
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    activeVault() {
      return this.$store.state.activeVault;
    },
    user() {
      return this.$user.sub;
      console.log(this.$user.sub);
    }
  },
  props: ["keepData"]
};
</script>

<style scoped>
body {
  background: white;
}
h1 {
  color: #fff;
  padding: 10px 0;
}
.card {
  box-shadow: 0 4px 8px 0 rgba(2, 2, 2, 0.2);
  transition: 0.3s;
  border: none;
  /* &:hover {
    box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.4);
  }
  a {
    color: initial;
    &:hover {
      text-decoration: initial;
    }
  } */
  /* .text-muted i {
    margin: 0 10px;
  } */
}
</style>

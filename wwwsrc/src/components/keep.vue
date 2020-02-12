<template>
  <div class="card">
    <a href="#">
      <img class="card-img-top" :src="keepData.img" alt="Card image cap" />
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <select
          class="form-control"
          @change="addVaultKeep($event, keepData.id)"
          v-if="$auth.isAuthenticated"
        >
          <option value selected disabled>Select Vault</option>
          <option
            v-for="vault in userVault"
            :value="vault.id"
            :key="vault.id"
            >{{ vault.name }}</option
          >
        </select>
        <p class="card-text">
          <small class="text-muted"
            ><i class="fas fa-eye"></i>{{ keepData.views
            }}<i class="far fa-user"></i>{{ keepData.keeps
            }}<i class="fas fa-calendar-alt"></i>{{ keepData.shares }}</small
          >
        </p>
      </div>
    </a>
  </div>
</template>

<script>
export default {
  name: "keep",
  methods: {
    addVaultKeep(event, KeepId) {
      let VaultId = parseInt(event.target.value);
      let vaultKeep = { VaultId, KeepId };
      this.$store.dispatch("addVaultKeep", vaultKeep);
    }
  },
  props: ["keepData"]
};
</script>

<style scoped>
body {
  background: #232321;
}
h1 {
  color: #fff;
  padding: 10px 0;
}
.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
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

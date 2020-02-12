<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <h2>Vault Creator 3000</h2>
    <br />
    <br />
    <form @submit.prevent="createVault">
      <input
        type="text"
        placeholder="title"
        v-model="newVault.title"
        required
      />
      <input
        type="text"
        placeholder="description"
        v-model="newVault.description"
      />

      <button type="submit">Create Vault</button>
    </form>
    <br />
    <dl>
      <div v-for="vault in vaults" :key="vault.id">
        <dt>
          <router-link
            :to="{ name: 'vault', params: { vaultId: vault.id } }"
            @click="setActiveVault"
            >{{ vault.title }}</router-link
          >
          <button class="btn btn-danger" @click="deleteVault(vault.id)">
            <i class="fas fa-trash-alt trash-right"></i>
          </button>
        </dt>
      </div>
    </dl>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  methods: {
    createVault() {
      let vault = { ...this.newVault };
      this.$store.dispatch("createVault", vault);
      this.newVault = { name: "", description: "" };
    },
    deleteVault() {
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  computed: {}
};
</script>

<style></style>

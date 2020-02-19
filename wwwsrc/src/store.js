import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 10000,
  withCredentials: true
});

export default new Vuex.Store({
  //#region--STATE--
  state: {
    publicKeeps: [],
    privateKeeps: [],
    vaults: [],
    userVaults: [],
    activeUser: {},
    activeVault: {},
    vaultKeeps: []
  },
  ////#endregion
  //#region--MUTATIONS--
  mutations: {
    setActiveUser(state, user) {
      state.activeUser = user;
    },
    addKeep(state, data) {
      state.publicKeeps.push(data);
    },
    setKeeps(state, data) {
      state.publicKeeps = data;
    },
    setActiveKeeps(state, data) {
      state.privateKeeps = data;
    },
    resetState(state) {
      (state.publicKeeps = []),
        (state.privateKeeps = []),
        (state.vaults = []),
        (state.activeUser = {}),
        (state.vaultKeeps = []),
        (state.activeVault = []);
    },
    addVault(state, data) {
      state.vaults.push(data);
    },
    setVaults(state, data) {
      state.vaults = data;
    },
    setActiveVault(state, data) {
      state.activeVault = {};
      state.activeVault = data;
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data;
    }
  },
  ////#endregion
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    //#region --KEEPS--
    async createKeep({ commit, dispatch }, keepData) {
      debugger;
      let res = await api.post("keeps", keepData);
      commit("addKeep", res.data);
    },
    async getKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setKeeps", res.data);
      console.log("this is from getKeeps", res.data);
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      debugger;
      let res = await api.delete(`keeps/${keepId}`, keepId);
      debugger;
      // dispatch("getKeepsByVaultId", keepData.vaultId)
      dispatch("getKeeps");
      //NOTE Will need to add get keeps in here as well
    },
    async editKeep({ commit, dispatch }, keepData) {
      let res = await api.put("keeps/" + keepData.id, keepData);
      dispatch("getKeeps");
    },
    //#endregion

    //#region --VAULTS--
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");

      commit("setVaults", res.data);
      console.log("vaults page", res.data);
    },
    async getVaultsById({ commit, dispatch }, id) {
      let res = await api.get("vaults/" + id);
      commit("setVaults", res.data);
    },
    async createVault({ commit, dispatch }, vaultData) {
      let res = await api.post("vaults", vaultData);

      commit("addVault", res.data);
    },
    async editVault({ commit, dispatch }, vaultData) {
      let res = await api.put("vaults/" + vaultData._id, vaultData);
      dispatch("getVaults");
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      let res = await api.delete("vaults/" + vaultId);
      dispatch("getVaults");
    },
    async setActiveVault({ commit, dispatch }, vaultId) {
      let res = await api.get("vaults/" + vaultId);
      commit("setActiveVault", res.data);
    },
    //#endregion

    //#region --VAULTKEEPS--
    async getKeepsByVaultId({ commit, dispatch }, vaultId) {
      let res = await api.get("vaultkeeps/" + vaultId + "/keeps");
      commit("setVaultKeeps", res.data);
    },
    async addVaultKeep({ commit, dispatch }, data) {
      let res = await api.post("vaultkeeps", data);
      dispatch("getKeepsByVaultId", res.data.vaultId);
    },
    async deleteVaultKeep({ commit, dispatch }, data) {
      let res = await api.delete(
        "vaultkeeps/" + data.vaultId + "/keeps/" + data.keepId
      );
      dispatch("getKeepsByVaultId", data.vaultId);
    }

    //#endregion
  }
});

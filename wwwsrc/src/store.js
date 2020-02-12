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
  timeout: 8000,
  withCredentials: true
});

export default new Vuex.Store({
  //#region--STATE--
  state: {
    publicKeeps: [],
    privateKeeps: [],
    vaults: [],
    userVaults: [],
    activeUser: {}
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
    resetState(state) {
      (state.publicKeeps = []),
        (state.privateKeeps = []),
        (state.vaults = []),
        (state.activeUser = {});
    },
    addVaults(state, data) {
      state.vaults.push(data);
    },
    setVaults(state, data) {
      state.vaults = data;
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
      console.log(keepData);
      let res = await api.post("keeps", keepData);
      commit("addKeep", res.data);
    },
    async getKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setKeeps", res.data);
    },
    async deleteKeep({ commit, dispatch }, keepData) {
      let res = await api.delete(`keeps/${keepData._id}`);
      dispatch("getKeepsByVaultId", keepData.vaultId);

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
    },
    async getVaultsByTeamId({ commit, dispatch }, teamId) {
      let res = await api.get("teams/" + teamId + "/vaults");
      commit("setVaults", res.data);
    },
    async createVault({ commit, dispatch }, vaultData) {
      let res = await api.post("vaults", vaultData);
      commit("putVault", res.data);
    },
    async editVault({ commit, dispatch }, vaultData) {
      let res = await api.put("vaults/" + vaultData._id, vaultData);
      dispatch("getVaults");
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      let res = await api.delete("vaults/" + vaultId);
      dispatch("getVaults");
    },
    //#endregion

    //#region --VAULTKEEPS--
    async getKeepsByVaultId({ commit, dispatch }, vaultId) {
      let res = await api.get("vaultkeeps/" + vaultId + "/keeps");
      commit("setKeeps", res.data);
    }

    //#endregion
  }
});

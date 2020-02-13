<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 input-header">
        <h1 style="text-align: center;">Keepr of the Keeps</h1>
        <div class="home">
          <form
            @submit.prevent="createKeep"
            class="form-inline"
            style="justify-content: space-evenly;"
            role="form"
          >
            <!--Name Input-->
            <div class="md-form">
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Name"
                v-model="newKeep.name"
                required
              />
            </div>
            <!--Description Input-->
            <div class="md-form">
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Description"
                v-model="newKeep.description"
                required
              />
            </div>
            <div class="md-form">
              <input
                type="text"
                class="form-control"
                id="img"
                placeholder="image"
                v-model="newKeep.img"
              />
            </div>
            <div class="custom-control custom-checkbox">
              <input
                type="checkbox"
                class="custom-control-input"
                id="defaultChecked2"
                v-model="newKeep.isPrivate"
                checked
              />
              <label class="custom-control-label" for="defaultChecked2"
                >Make Private?</label
              >
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
      </div>
      <div class="col-md-12 card-columns" style="flex-wrap: wrap;">
        <a v-for="keep in keeps" :key="keep.id">
          <keep-component :keepData="keep" />
          <!-- NOTE is where cards will go -->
        </a>
      </div>
    </div>
  </div>
</template>

<script>
import KeepComponent from "../components/keep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: false,
        views: 0,
        shares: 0,
        keeps: 0
      }
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      // this.$store.commit("resetState");
      this.$store.dispatch("logout");
    },
    createKeep() {
      let keep = { ...this.newKeep };
      debugger;
      this.$store.dispatch("createKeep", keep);
      this.newKeep = {
        name: "",
        description: "",
        img: "",
        isPrivate: false,
        views: 0,
        shares: 0,
        keeps: 0
      };
    }
  },
  components: {
    KeepComponent
  }
};
</script>
<style scoped>
.col-12 {
  padding-bottom: 1.5rem;
  border-bottom: 0.2rem solid rgba(193, 192, 192, 0.626);
}
.keep-section {
  border: 0.2rem solid greenyellow;
}

h1 {
  font-family: Montserrat;
  margin-bottom: 1rem;
}
input {
  border-left: 0;
  border-right: 0;
  border-top: 0;
}
</style>

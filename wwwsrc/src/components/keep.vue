<template>
  <div class="card">
    <a href="#">
      <img class="card-img-top" src="" alt="Card image cap" />
      <div class="card-body">
        <h5 class="card-title">Lorem ipsum dolor sit amet.</h5>
        <p class="card-text">
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ab
          accusantium ad alias, aliquid amet aspernatur atque culpa cum debitis
          dicta doloremque, dolorum ea eos et excepturi explicabo facilis harum
          illo impedit incidunt laborum laudantium...
        </p>
        <p class="card-text">
          <small class="text-muted"
            ><i class="fas fa-eye"></i>1000<i class="far fa-user"></i>admin<i
              class="fas fa-calendar-alt"
            ></i
            >Jan 20, 2018</small
          >
        </p>
      </div>
    </a>
  </div>
</template>

<script>
export default {
  name: "keep",
  methiods: {
    //share task
    //
  }
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

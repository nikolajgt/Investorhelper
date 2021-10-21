<template>
    <div id="nav">
        <div class="SidebarTop">
            <h3>Welcome to</h3>
            <h1>Investor helper</h1>
        </div>
        <div class="SidebarContent">
            <router-link to="/">Home</router-link> 
            <router-link to="/about">About</router-link>
            <router-link to="/about">About</router-link>
            <router-link to="/about">About</router-link>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style scoped>
#nav {
  width: 200px;
  height: 100vh;
  position: absolute;
  top:0;
  left: 0;
    background: rgb(21,38,66);
    background: linear-gradient(90deg, rgba(21,38,66,1) 80%, rgba(8,27,51,1) 100%, rgba(0,212,255,1) 100%);
    z-index: 1000;
}

.SidebarTop {
    height: 200px;
    width: 100%;
    background-color: red;
    text-align: center;
    padding-top:10%;
}

.SidebarTop h3 {
    font-size: 1em;
    
}

.SidebarContent {
    display: flex;
    flex-direction: column;
}
</style>
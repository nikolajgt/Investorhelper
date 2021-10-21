import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import About from '../views/About.vue'
import CreateUser from '../views/CreateUser.vue'
import store from '../store/index.js'

const routes = [
  { path: "/", name: Home, component: Home, meta: { requiredAuth: true } },
  { path: "/about", name: About, component: About, meta: { requiredAuth: true } },
  { path: "/login", name: Login, component: Login, meta: { requiredAuth: false } },
  { path: "/createUser", name: CreateUser, component: CreateUser, meta: { requiredAuth: false } },

]


const router = createRouter({
  history: createWebHashHistory(),
  routes,
})

router.beforeEach((to, from, next) => {
  if(!store.getters["auth/getAuthData"].Token) {
 
    const access_token = localStorage.getItem("access_token");
    const refresh_token = localStorage.getItem("refresh_time");

    if(access_token) {
      const data = {
        access_token:access_token,
        refresh_token:refresh_token,
      };

    store.commit("auth/saveTokenData", data.access_token);
 
    }
  }
 
  const auth = store.getters["auth/isTokenActive"];
 
  if(to.fullPath == "/login" ) {
    return next();
  }
 
  else if(auth && !to.meta.requiredAuth) { 
    return next({path:"/login"});
  }
 
  else if(!auth && to.meta.requiredAuth) {
    return next({path: '/login'});
  }
 
  return next();
 
 });
 


//Routing guard, gør så man ikke bare kan access andre sider uden man er logget ind

export default router

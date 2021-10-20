import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import About from '../views/About.vue'
import CreateUser from '../views/CreateUser.vue'
 //import store from '../store/index.js'

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




//Routing guard, gør så man ikke bare kan access andre sider uden man er logget ind

export default router

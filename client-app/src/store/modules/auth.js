import { jwtDecrypt, tokenAlive } from "./JwtParser";
import axios from 'axios';


 const instance = axios.create({
     baseURL: 'http://localhost:55543/',
     timeout: 40000,
     headers: {'Content-Type': 'application/json; charset=utf-8'}
 });

 const userLogin = '/User/authenticate';


const state = () => ({
    authData: {
        Token: '',
        Unique_name: '',
        Expire: '',
        Issued: ''
    },
    loginStatus: "",
  });

const getters = {
    getLoginStatus(state) {
        return state.loginStatus;
    },
    getAuthData(state) {
        return state.authData;
    },
    isTokenActive(state) {
        if(!state.authData.Expire) {
            return false;
        }

        return tokenAlive(state.authData.Expire);
    }
};
 
const actions = {                               //Her skal jeg lave min api kald logic
    async login({commit}, payload) {
        await instance.post(userLogin, {
            Username: payload.Username,
            Password: payload.Password
        })
        .then(response => { 
            commit("saveTokenData", response.data)              // ARBEJDE HER SIDST!!
            commit("setLoginStatus", "success");
           
        })
    }
};
 
const mutations = {
    saveTokenData(state, data) {
        const tokenData = jwtDecrypt(data);
        const newTokenData = {
            Token: data,
            Unique_name: tokenData.unique_name,
            Expire: tokenData.exp,
            Issued: tokenData.iat,
        };
        
        localStorage.setItem("access_token", data);
        localStorage.setItem("refresh_time", tokenData.exp)
        
        state.authData = newTokenData;
    },
    setLoginStatus(state, value) {
        state.loginStatus = value;
    },
};

export default{
    namespaced:true,
    state,
    getters,
    actions,
    mutations
}
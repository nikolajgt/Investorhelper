import { jwtDecrypt } from "./JwtParser";
import axios from 'axios';


 const instance = axios.create({
     baseURL: 'http://localhost:55543/',
     timeout: 40000,
     headers: {'Content-Type': 'application/json; charset=utf-8'}
 });

 const userLogin = '/User/authenticate';
//  const FinanceEndPointApi = '/Api';

const state = () => ({
    authData: {
        UserId: "",
        Username: "",
        Password: "",
        Token: "",
        RefreshToken: "",
        TokenExpire: "",
    },
    loginData: {
        Uname: "",
        Pword: ""
    },
    loginStatus: "",
  });

const getters = {
    getLoginStatus(state) {
        return state.loginStatus;
    }
};
 
const actions = {                               //Her skal jeg lave min api kald logic
    async login({commit}, payload) {
        await instance.post(userLogin, {
            Username: payload.Username,
            Password: payload.Password
        })
        .then(response => { 
            if(!response === null)
            commit("saveTokenData", response.data)
            commit("setLoginStatus", "success");
            console.log(response.data)
        })
        
        
    }
};
 
const mutations = {
    saveTokenData(state, data) {
        localStorage.setItem("access_token", data.access_token);
        localStorage.setItem("refresh_token", data.refresh_token);

        const jwtDecodedValue = jwtDecrypt(data.access_token);
        const newTokenData = {
            Token: data.access_token,
            RefreshToken: data.refresh_token,
            TokenExpire: jwtDecodedValue.exp,
            UserId: jwtDecodedValue.sub,
            Username: jwtDecodedValue.userName,
        };
        state.authData = newTokenData;
    },
    setLoginStatus(state, value) {
        state.loginStatus = value;
    }
};

export default{
    namespaced:true,
    state,
    getters,
    actions,
    mutations
}
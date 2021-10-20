import { createSequenceExpression } from '@vue/compiler-core';
import axios from 'axios';


 const instance = axios.create({
     baseURL: 'http://localhost:55543/',
     timeout: 40000,
     headers: {'Content-Type': 'application/json; charset=utf-8'}
 });

 const UserCreation = '/User/Create';


 const state = () => ({
    Creation: {
        Username: "",
        Password: "",
        Fullname: "",
        Email: "",
    }
});
 
 const getters = {

 };
  
 const actions = {                               //Her skal jeg lave min api kald logic
    async CreateUser({commit}, payload) {
        await instance.post(UserCreation, {
            Username: payload.Username,
            Password: payload.Password,
            Fullname: payload.Fullname,
            Email: payload.Email
        })
        .then(response => {
            
        })
    }
 };
  
 const mutations = {

 };
 
 export default{
     namespaced:true,
     state,
     getters,
     actions,
     mutations
 }
<template>
  <div class="container-fluid" id="login-view">
      <div class="Login-box">
          <div class="Login-upperhalf">
              <h5>Login</h5>
          </div>
          <div class="Login-lowerhalf">
                <label for="uname"><b>Username</b></label>
                <input type="text" placeholder="Enter Username" v-model="uname" name="uname" required>

                <label for="psw"><b>Password</b></label>
                <input type="password" placeholder="Enter Password" v-model="pword" name="psw" required>

                <button type="submit" @click="login()">Login</button>
                <div class="remember-me">
                    <input type="checkbox" checked="checked" name="remember">
                    <label>Remember me </label>
                </div>


          </div>
      </div>
  </div>
</template>

<script>
import {mapActions, mapGetters} from 'vuex';


export default {
    name: 'login-view',
    data(){
      return {
          uname: '',
          pword: '',
      }
    },
    computed: {
        ...mapGetters("auth",{
            getterLoginStatus: "getLoginStatus",
        })
    },
    methods: {
        ...mapActions("auth", {
            actionLogin: "login"
        }),
        async login() {
            await this.actionLogin({Username:this.uname, Password:this.pword});
            if(this.getterLoginStatus === "success") {
                this.$router.push("/")
            }
            else {
                alert("failed to login")
            
            }
        }
    }
}
</script>

<style lang="scss">
$background-color: #081B33;
$background-color-2: #152642;

$border-color: #BCE0FD;

$text-color:  #2699FB;

.container-fluid {
    width: 100vw;
    height: 100vh;
    background-color: $background-color;
    padding: 0;
    margin: 0;
    position: absolute;
    top: 0;
    left: 0;

    .Login-box {
        width: 300px;
        height: 400px;
        background-color: $background-color;
        margin: auto;
        top: 20%;
        position: relative;
        border-radius: 5px;

        .Login-upperhalf {
            position: relative;
            height: 50px;
            border-bottom: 1px solid $text-color;

            h5 {
                margin: 0;
                padding: 0;
                position: relative;
                top: 0;
                color:$text-color;
                font-size: 20px;
            }
        }

        .Login-lowerhalf {
            display:flex;
            flex-direction: column;
            justify-content: space-between;

            b {
                float: left;
                margin-bottom: 5px;
                color: $text-color;
            }
            
            b:first-child {
                margin-top: 20px;
            }

            input {
                margin-bottom: 10px;
                height: 30px;
                background-color: $background-color-2;
                border: 1px solid $text-color;
                border-radius: 0px;
                color: $text-color;
            }

            input:focus {
                outline: 1px solid $border-color;
            }

            button {
                width: 100px;
                height: 25px;
                margin: auto;
                margin-top: 10px;
                background-color: $background-color-2;
                color: $text-color;
                outline: 1px solid $text-color;
                border: 0;
            }

            button:hover {
                background-color: #004b8c;
            }

            .remember-me {
                margin: 0;
                display:flex;
                flex-direction:row;
                justify-content: center;
                position: relative;
                top: 20px;

                input {
                    margin: 0;
                    height: 16px;
                    width: 16px;
                    margin-right: 20px;
                }

                label {
                    color: $text-color;
                }
                
            }
        }
    }
}



</style>
<template>
  <div class="container-fluid" id="CreateUser">
      <div class="CreateUser-box">
          <div class="CreateUser-left-box">
              <h5>Username</h5>
              <h5>Password</h5>
              <h5>Fullname</h5>
              <h5>Email</h5>
          </div>
          <div class="CreateUser-right-box">
               <input type="text" placeholder="JohnDoe0000" v-model="uname" name="uname" required>
               <input type="password" placeholder="*********" v-model="pword" name="pword" required>
               <input type="text" placeholder="John Doe" v-model="fname" name="fname" required>
               <input type="text" placeholder="JohnDoe@outlook.com" v-model="email" name="email" required>
               
               <button>Create user</button>
          </div>
      </div>
  </div>
</template>

<script>
export default {
    name: 'CreateUser',
    data() {
        return {
            uname: '',
            pword: '',
            fname: '',
            email: '',
        }
    }
}
</script>

<style lang="scss" scoped>
$background-color: #081B33;
$background-color-2: #152642;

$border-color: #BCE0FD;

$text-color:  #2699FB;

html {
    padding: 0;
    margin:0;
}

.container-fluid {
    width: 100vw;
    height: 100vh;
    position:absolute;
    background-color: $background-color;
    padding: 0;
    margin: 0;
    top: 0;
    left: 0;

    .CreateUser-box {
        height: 520px;
        max-width: 800px;
        margin: auto;
        position: relative;
        top: 100px;
        display: flex;

        .CreateUser-left-box {
            height: 520px;
            width: 75%;
            border-right: 1px solid $text-color;
            text-align: right;
            display: flex;
            flex-direction: column;
            gap: 67px;

            h5 {
                position: relative;
                margin: 0;
                padding: 0;
                font-size: 20px;
                color:$text-color;
                margin-right: 40px;
            }
            h5:first-child {
                margin-top: 107px;
            }

        }

        .CreateUser-right-box {
            width: 100%;
            height:520px;
            display: flex;
            flex-direction: column;
            gap: 53px;

            input {
                height: 30px;
                width: 70%;
                margin-left: 20px;
                background-color: $background-color-2;
                outline: 1px solid $text-color;
                border: 0;
                color: $text-color;
                padding: 5px;
                font-family: 'JetBrains Mono';
            }
            
            input:first-child {
                margin-top: 100px;
            }

            button {
                height: 30px;
                width: 40%;
                margin-left: 20px;
                color: $text-color;
                background-color:$background-color-2;
                outline: 1px solid $text-color;
                border: 0;
                font-family: 'JetBrains Mono';
            }

            button:hover {
                background-color: #004b8c;
            }
        }
    }
}

</style>
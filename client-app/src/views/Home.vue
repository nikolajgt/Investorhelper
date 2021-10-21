<template>
  <div class="containers">
    <div class="ShowStocksList">
      <div class="ShowStocksListInfo">
        <div class="DividerSymbol">
          <h1 class="h4"> {{$store.state.symbol}} </h1>
        </div>
        <div class="DividerLastPrice">
           <h1 class="h5"> {{$store.state.previousClose}} </h1>
        </div>
        <div class="DividerChange">
           <h1> {{$store.state.priceNow}} </h1>
        </div>
        <h1>{{$store.state.procentChange}}</h1>
      </div>
      <Stocks />
    </div>
    <div class="GraphStocks">
      <div class="UpperBox">
        <button class="btn btn-primary" @click="logout()">Button </button>
      </div>
      <div class="LowerBox">

      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import Stocks from '../components/OverviewStock/stocks.vue'
import {mapMutations} from 'vuex';

export default {
  name: 'Home',
  components: {
    Stocks,
  },
  methods: {
    ...mapMutations("auth", {
      actionLogout: "removeTokenData",
    }),
     logout() {
      window.location.reload();
      localStorage.clear();
    }
  }
}
</script>

<style scoped lang="scss">
.containers {
  width: calc(100% - 200px);
  height: 100vh;
  background-color:#081B33;
  position: absolute;
  top:0;
  right:0;
  display: flex;

    h1 {
      text-align: center;
      text-transform: uppercase;
      color: rgb(255, 254, 254);
      font-size: 1vw;
      vertical-align: center;
      padding:0.5rem;
    }

    .ShowStocksList {
      margin:30px;
      height: 93%;
      width: 50%;
      background-color:#152642 ;
      outline: 2px solid #204277;
      box-shadow: 0 0 1pt 2pt cornflowerblue;

      .ShowStocksListInfo {
        height: 50px;
        width: 100%;
        border-bottom: 1px solid cornflowerblue;
        margin-bottom: 10px;
        display: flex;

        .DividerSymbol {
          width: 25%;
          height: 100%;
          border-right: 1px solid cornflowerblue;
        }

        .DividerLastPrice {
          width: 25%;
          height: 100%;
          border-right: 1px solid cornflowerblue;
        }

        .DividerChange {
          width: 25%;
          height: 100%;
          border-right: 1px solid cornflowerblue;
        }

        .list-items {
          left: 20%;
          position: relative;
          text-decoration: none;
          color: inherit;
          
        }

      }
    }
    .GraphStocks {
      margin: 30px 30px 30px 0px;
      height: 93%;
      width: 50%;
    }

    .UpperBox {
      margin-bottom: 30px;
      background-color: #152642;
      height: 48%;
      width: 100%;
      outline: 2px solid #204277;
      box-shadow: 0 0 1pt 2pt cornflowerblue;
    }

    .LowerBox {
      background-color: #152642;
      height: 48%;
      width: 100%;
      outline: 2px solid #204277;
      box-shadow: 0 0 1pt 2pt cornflowerblue;
    }
}
</style>
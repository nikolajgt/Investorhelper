<template>
<ul>
    <li v-for="(symbol, index) in userstocks" :key="index" class="list-group-item list-group-item-action">
       <h4 class="stock-symbol"> {{ symbol }}  </h4>
    </li>
</ul>
    <input type="text" v-model="symbol" placeholder="Find stocks..." @keypress.enter="save" />
</template>

<script>
import { useStore } from 'vuex';
import { computed, ref } from 'vue';

export default {
    setup() {
        const store = useStore();

        const userstocks = computed(() => store.state.stocks);

        

        const symbol = ref('');

        function save() {
            if(symbol.value.length >= 2 && symbol.value.length <= 4) {
                store.commit('SAVE_STOCK', symbol.value)
                symbol.value = '';
            }
        }

        return {
            userstocks,
            symbol,
            save
        }
    },
    created() {
        console.log(this.financestocks)
    }
}
</script>

<style scoped lang="scss">

h4, p {
    text-align: center;
    width: 50px;
    margin-bottom: 0px;
}


.list-group-item {
    margin-top: 5px;
    background-color: #506680;
    display: flex;
    flex-direction: row;
    justify-content:space-around;
    align-items:center;
    height: 40px;
    border-radius: 5px;

    .list-group-item-action {
        text-decoration: none;
        margin: 5px;
        

    }
}

</style>
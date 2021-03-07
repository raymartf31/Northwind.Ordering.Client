<template>
  <div id="app">
    <h1>Oli's Food Cart</h1>
    <Products @clicked="onOrderUpdated" />
    <Order :key="orderComponentKey"/>
    <SMS />
  </div>
</template>

<script>
import Order from './components/Order.vue'
import Products from './components/Products.vue'
import SMS from './components/SMS.vue'

export default {
  name: 'app',
  components: {
    Order,
    Products,
    SMS
  },
  data: () => {
    return {
      orderComponentKey: 0
    };
  },
  methods:{
    onOrderUpdated() {
      this.orderComponentKey += 1;
    }
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
  margin-left: 15px;
}
</style>

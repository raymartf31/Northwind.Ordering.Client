<template>
    <div class="order-container">
      <div v-for="order in orders" :key="order.orderID">
        <h3>Order#: {{ order.orderID }}</h3>
        <table>
          <tr v-for="detail in order.orderDetails" :key="detail.productID">
            <td>{{ detail.quantity }}</td>
            <td>{{ detail.product.productName }}</td>
            <td>{{ detail.unitPrice }}</td>
            <td></td>
            <td></td>
          </tr>
        </table>
      </div>
    </div>
</template>

<script>

import axios from 'axios';

export default {
  name: 'Order',
  data: () => {
    return {
      orders: []
    };
  },
  methods: {
    getOrder() {
      console.log("getting order...");
      let vm = this;
      axios({
        method: 'get',
        url: '/api/order/order',
        data: {}
        })
        .then(function (response) {
          vm.orders = response.data;
          console.log(response);
          })
          .catch(function (error) {
            console.log(error);
            });
    }
  },
  mounted(){
    this.getOrder();
  }
}
</script>

<style scoped>
.order-container {
  text-align: left;
}
td {
  padding: 10px 15px 0 15px;
}
</style>

<template>
<div>
    <div>
        <h6>Select an item.</h6>
    </div>
    <div class="row product" >
      <div v-for="product in products" :key="product.productID">
        <div class="col-md-4 col-sm-4">
            <button class="btn btn-primary product-btn" @click="addOrderItem(product.productID)">{{ product.productName }}</button>
        </div>
      </div>
    </div>
</div>
</template>

<script>

import axios from 'axios';

export default {
  name: 'Products',
  components:{
  },
  data: () => {
    return {
      products: []
    };
  },
  methods: {
    getProducts() {
      console.log("getting products...");
      let vm = this;
      axios({
        method: 'get',
        url: '/api/order/products',
        data: {}
        })
        .then(function (response) {
          vm.products = response.data;
          console.log(response);
          })
          .catch(function (error) {
            console.log(error);
            });
    },
    addOrderItem(productId) {
      console.log("adding order item...");
      let vm = this;
      const selectedProduct = vm.products.find(p => p.productID === productId);
        console.log(selectedProduct);
      axios({
        method: 'post',
        url: '/api/order/addorderitem',
        data: {
            orderId: 10250,
            productId: selectedProduct.productID,
            unitPrice: selectedProduct.unitPrice,
            quantity: 1
        }})
        .then(function (response) {
          console.log(response);
            vm.$emit('clicked');
          })
          .catch(function (error) {
            console.log(error);
            });
    }
  },
  mounted(){
    this.getProducts();
  }
}
</script>

<style scoped>
.product-btn {
  width: 120px;
  height: 70px;
  margin: 10px 5px;
  font-size: 14px;
}
.product {
    margin-bottom: 15px;
}

h6 {
    font-style: italic;
}
</style>

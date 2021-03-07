<template>
    <div class="sms">
      <button class="btn btn-info sms-btn" @click="sendSMS">Send SMS</button>
    </div>
</template>

<script>

import axios from 'axios';

export default {
  name: 'SMS',
  components:{
  },
  data: () => {
    return {
    };
  },
  methods: {
    sendSMS() {
      console.log("sending sms...");
      let vm = this;
      axios({
        method: 'post',
        url: '/api/sms/sms',
        data: {}
        })
        .then(function (response) {
          console.log(response);
          })
          .catch(function (error) {
            console.log(error);
            });
    }
  },
  mounted(){
  }
}
</script>

<style scoped>
.sms-btn {
  width: 100px;
  height: 50px;
  font-size: 14px;
}
.sms {
    margin: 15px 5px;
    text-align: left;
}
</style>

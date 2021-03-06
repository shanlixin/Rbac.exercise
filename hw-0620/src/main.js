import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import axios from 'axios'

const service = axios.create({
  baseURL: "http://localhost:28073/api/"
})
service.defaults.withCredentials = true;
service.defaults.headers.common['Authorization'] = "bearer " + localStorage.getItem("token");
Vue.prototype.$axios = service
Vue.use(ElementUI);
Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

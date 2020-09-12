import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import VueRouter from 'vue-router'
import Home from './components/Home.vue'
import Items from './components/Items/Items.vue'
import Item from './components/Items/ItemDetails.vue'
import PriceEdit from './components/Items/EditPrice.vue'
import ItemEdit from './components/Items/EditItem.vue'
import InsertItem from './components/Items/InsertItem.vue'
import PriceInsert from './components/Items/InsertPrice.vue'






Vue.config.productionTip = false

Vue.use(VueRouter);
Vue.use(BootstrapVue);

Vue.config.productionTip = false

const routes = [ 
  { path: '/', component: Home },
  { path: '/items', component: Items },
  { path: '/items/insert', component: InsertItem },
  { path: '/items/:id/prices/insert', component: PriceInsert },
  { path: '/items/:id/prices/:priceId/edit', component: PriceEdit },
  { path: '/items/:id/edit', component: ItemEdit },
  { path: '/items/:id', component: Item },

];

const router = new VueRouter({
  routes,
  mode:'history'
});

new Vue({
  el: '#app',
  router,
  render: h =>h(App)
});

<template>
    <div class="pt-5 container">
        <h1 style="text-align:center;">Item details</h1>
        <div class="row pt-5 ml-1">
            <table class="table table-striped table-responsive-sm">
                    <tr>
                        <th>SKU</th>
                        <td>{{item.sku}}</td>
                    </tr>
                    <tr>
                        <th>EAN</th>
                        <td>{{item.ean}}</td>
                    </tr> 
                    <tr>
                        <th>Name</th>
                        <td>{{item.name}}</td>
                    </tr>                                                                 
                    <tr>
                        <th>Unit of measure</th>
                        <td>{{item.unitOfMeasure}}</td>
                    </tr>
            </table>
        </div>
        <h1 class="mb-3" style="text-align:center;">Item Prices</h1>
        <a class="btn btn-primary mb-3" style="float:right;" @click="insertPrice()">Add new price</a>
        <b-table responsive striped hover
            :items="prices"
            :fields="fields">
                <template v-slot:cell(actions)="row">
                    <b-button variant="warning" @click="editPrice(row.item)">Edit</b-button> |
                    <b-button variant="info" @click="changePriceActiveState(row.item)">Change active state</b-button>
                </template>
            <template v-slot:table-busy>
                <div class="text-center text-primary my-2">
                    <b-spinner class="align-middle"></b-spinner>
                    <strong>Loading...</strong>
                </div>
            </template>
        </b-table>
    </div>
</template>

<script>
import axios from 'axios';
const apiUrl = process.env.VUE_APP_API;
export default {
    data() {
        return {
            item: {
                sku: '',
                ean: '',
                name: '',
                unitOfMeasure: '',
            },
            prices: [],
            fields: [    
                { key: 'price' },
                { key: 'active'}, 
                'actions',
            ],
        }
    },
    created() {
        this.fetchItem();
        this.fetchItemPrices();
    },

    methods: {      
        fetchItem(){
            let vm = this;
            axios.get(apiUrl + `/items/${this.$route.params.id}`)
            .then(function (response) {
                vm.item = response.data;
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        },

        fetchItemPrices() {
            let vm = this;
            axios.get(apiUrl + `/items/${this.$route.params.id}/prices`)
            .then(function (response) {
                vm.prices = response.data;
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        },

        changePriceActiveState(price) {
            let vm = this;
            axios.get(apiUrl + `/items/${this.$route.params.id}/prices/${price.id}/state`)
            .then(function (response) {
                if(response.statusText == 'OK')
                    vm.fetchItemPrices();
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        },
        editPrice(price){
            this.$router.push(`/items/${price.itemSku}/prices/${price.id}/edit`); 
        },
        insertPrice() {
            this.$router.push(`/items/${this.$route.params.id}/prices/insert`); 
        }
    }
}
</script>
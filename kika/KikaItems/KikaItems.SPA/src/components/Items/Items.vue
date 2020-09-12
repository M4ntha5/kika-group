<template>
    <div class="pt-5 container">
        <a class="btn btn-primary mb-3" style="float:right;" variant="primary" @click="openItemInsertForm()">Add new item</a>
        <b-table responsive striped hover 
            :busy="isBusy"
            :items="items"
            :fields="fields">
                <template v-slot:cell(actions)="row">
                    <b-button variant="info" @click="itemDetails(row.item)">Details</b-button> |
                    <b-button variant="warning" @click="editItem(row.item)">Edit</b-button> |
                    <b-button variant="danger" @click="deleteItem(row.item)">Delete</b-button>
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
            items: [],
            fields: [    
                { key: 'sku' },
                { key: 'ean' },
                { key: 'name'},
                { key: 'unitOfMeasureName', label: 'Unit of measure' },   
                'actions',
            ],
            isBusy: true
        }
    },
    created() {
        this.fetchItems();
    },

    methods: {      
        fetchItems(){
            let vm = this;
            axios.get(apiUrl + '/items')
            .then(function (response) {
                vm.items = response.data;
                vm.isBusy = false;
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        },
        itemDetails(item) {
            this.$router.push(`/items/${item.sku}`); 
        },
        editItem(item) {
            this.$router.push(`/items/${item.sku}/edit`); 
        },
        deleteItem(item) {
            let vm = this;
            axios.delete(apiUrl + `/items/${item.sku}`)
            .then(function (response) {
                if(response.statusText == 'OK')
                    vm.fetchItems();
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        },
        openItemInsertForm(){
            this.$router.push('/items/insert'); 
        }
    }
}
</script>
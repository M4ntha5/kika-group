<template>
    <div>
        <b-form class="pt-4 container">
            <div class="form-row">
                <b-form-group class="col-sm-6 mb-3" label="Sku"
                    :invalid-feedback="invalidFeedback"
                    :valid-feedback="validFeedback"
                    :state="skuState">
                    <b-form-input name="make-input" :state="skuState" required
                        v-model="item.sku">
                    </b-form-input>
                </b-form-group>    
                <b-form-group class="col-sm-6 mb-3" label="Ean"
                    :invalid-feedback="invalidFeedback"
                    :valid-feedback="validFeedback"
                    :state="eanState">
                    <b-form-input name="make-input" :state="eanState" required
                        v-model="item.ean">
                    </b-form-input>
                </b-form-group>   
            </div>
            <div class="form-row">
                <b-form-group class="col-sm-6 mb-3" label="Name"
                    :invalid-feedback="invalidFeedback"
                    :valid-feedback="validFeedback"
                    :state="nameState">
                    <b-form-input name="make-input" :state="nameState" required
                        v-model="item.name">
                    </b-form-input>
                </b-form-group>  
                <b-form-group label="Units of measure" class="col-sm-6 mb-3">
                    <b-form-select v-model="item.unitOfMeasure" :options="units"></b-form-select>
                </b-form-group> 
            </div>
            
            <div class="pt-3">
               <b-button type="submit" @click.prevent="onSubmit()" variant="primary">Save</b-button>
            </div>
        </b-form>
    </div>
</template>

<script>
import axios from 'axios';
const apiUrl = process.env.VUE_APP_API;
export default {
    data(){
        return {
            item: {
                sku: '',
                ean: '',
                name: '',
                unitOfMeasure: 'VNT'
            },
            units: [],
        }
    },
    created() {
        this.fetchUnitsOfMeasure();
    },
    computed: {
        eanState() {
            return this.item.ean != '' ? true : false
        },
        nameState() {
            return this.item.name != '' ? true : false
        },
        skuState() {
            return this.item.sku != '' ? true : false
        },
        invalidFeedback() {
            if (this.item.sku == '' || this.item.name == '' || this.item.ean == '')
                return 'Field required and cannot be empty';
            else 
                return 'Please enter a value';
        },
        validFeedback() {
            return this.state === true ? 'Looks good' : ''
        }
    },
    methods: {
        fetchUnitsOfMeasure() {
            let vm = this;
            axios.get(apiUrl + '/unitsOfMeasure')
            .then(function (response) {
                vm.units = response.data;
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        },

        onSubmit() {
            let vm = this;
            if(!this.eanState || !this.skuState || !this.nameState)
                return;

            axios.post(apiUrl + '/items', this.item)
            .then(function (response) {
                if(response.statusText == 'OK')
                    vm.$router.push('/items'); 
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        }
    }
}
</script>
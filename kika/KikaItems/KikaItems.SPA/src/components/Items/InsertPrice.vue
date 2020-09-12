<template>
    <div>
        <b-form class="pt-4 container">
            <div class="form-row">
                <b-form-group class="col-sm mb-3" label="Price"
                    :invalid-feedback="invalidFeedback"
                    :valid-feedback="validFeedback"
                    :state="priceState">
                    <b-form-input name="make-input" :state="priceState"
                        v-model="data.price">
                    </b-form-input>
                </b-form-group>     
            </div>

            <div class="form-row">
                <b-form-group label="Is active" class="col-sm mb-3">
                    <b-form-select v-model="data.active" :options="options" :state="activeState"></b-form-select>
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
            data: {
                price: 0,
                active: null
            },
            options: [
                { value: null, text: 'Please select an option' },
                { value: true, text: 'Active' },
                { value: false, text: 'Unactive' },
            ]
        }
    },
    computed: {
        priceState() {
            return this.data.price > 0 ? true : false
        },
        activeState() {
            return this.data.active != null ? true : false
        },
        invalidFeedback() {
            if (this.data.price > 0)
                return '';
            else if (this.data.price < 0) 
                return 'Price must be more than 0';
            else 
                return 'Please enter a number';
        },
        validFeedback() {
            return this.state === true ? 'Looks good' : ''
        }
    },
    methods: {

        onSubmit() {
            let vm = this;
            if(!this.priceState || !this.activeState)
                return;
            console.log(this.data);
            axios.post(apiUrl + `/items/${this.$route.params.id}/prices`, this.data)
            .then(function (response) {
                if(response.statusText == 'OK')
                    vm.$router.push(`/items/${vm.$route.params.id}`); 
            })
            .catch(function (error){
                console.log(error);
                console.log(error.response.data);
            })
        }
    }
}
</script>
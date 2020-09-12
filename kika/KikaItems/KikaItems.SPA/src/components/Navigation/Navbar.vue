<template>
    <div>
        <nav class="navbar navbar-expand-lg navbar-light bg-light my-nav">
            <router-link to="/" class="navbar-brand">Kika</router-link>
            <button class="navbar-toggler" data-toggle="collapse" 
                  data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent">
                  <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <router-link to="/items" class="nav-link">Items</router-link>
                    </li>                                               
                </ul>
            </div>
        </nav>    
    </div>
</template>
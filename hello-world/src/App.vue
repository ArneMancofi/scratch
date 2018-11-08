<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      fixed
      app
    >
      <v-list dense>
        <v-list-tile @click="">
          <v-list-tile-action>
            <v-icon>home</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Home</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile @click="">
          <v-list-tile-action>
            <v-icon>contact_mail</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Contact</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar color="indigo" dark fixed app>
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title>Hello World</v-toolbar-title>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-layout
          justify-center
          align-center
        >
          <v-flex text-xs-center>
            <v-list v-for="company in companies" :key="company.id">
              <v-list-tile>
                {{ company.name }}
              </v-list-tile>
            </v-list>
            <v-list v-for="error in errors" :key="error">
              <v-list-tile>Error: {{ error }}</v-list-tile>
            </v-list>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
    <v-footer color="indigo" app>
      &nbsp; <span class="white--text">&copy; 2017</span>
    </v-footer>
  </v-app>
</template>

<script>
import axios from 'axios'
import HelloWorld from './components/HelloWorld'

export default {
  name: 'App',
  components: {
    HelloWorld
  },
  data: () => ({
    drawer: null,
    errors: [],
    companies: [
      { "id" : 4, "name" : "SkunkPension" },
      { "id" : 5, "name" : "EfterLiv Forsikring" },
      { "id" : 6, "name" : "SælvForsikring" } ]
  }),
  created() {
    axios.get("https://arnes-hello-world.azurewebsites.net/api/HelloWorld")
    .then(response => new Promise(resolve => setTimeout(() => resolve(response), 2000)))
    .then(response => { this.companies = response.data; })
    .catch(e => this.errors.push(e));
  }
}
</script>


<template>
  <div>
    <h2>Login</h2>
    <div class="container">
      <label for="uname"><b>Umgebung</b></label>
         <select v-model="selectedenvironment">
    <option v-bind:value="{name: environment.name,id: environment.id}" v-for="environment in environments">
      {{environment.id + ' - ' +  environment.name }}
      </option>

</select>

    <label for="uname"><b>Benutzername</b></label>
    <input type="text" placeholder="Benutzername eingeben" name="loginname" v-model="loginname" required>

    <label for="psw"><b>Kennwort</b></label>
    <input type="password" placeholder="Kennwort eingeben" name="password" v-model="password" required>

    <button type="submit" @click="login">Login</button>
    
  </div>
    <p v-if="msg">{{ msg }}</p>
  </div>
</template>
<script>
import AuthService from '@/services/AuthService.js';

export default {
  data() {
    return {
      pwtoken: '',
      loginname: '',
      password: '',

      msg: '',
      environments: [
        {
            id: 1,
            name: 'Live'
        },
        {
            id: 2,
            name: 'Test'
        },
        {
            id: 3,
            name: 'Edu'
        },
        {
            id: 4,
            name: 'Local'
        },
      ],
      selectedenvironment: {
 
      }
    };
  },

  methods: {
    async login() {
      try {
        this.msg = 'führe Anmeldung durch...'
        const environment = this.selectedenvironment.id;
        const credentials = {

          loginname: this.loginname,
          password: this.password,
          environment: environment
        };
        const response = await AuthService.login(credentials);
       
        


        const ident = response;
        console.log('Ident');
        console.log(ident);
        const token = response.token;
        console.log('token');
        console.log(token);
              const mandatorId = response.mandatorIds[0];

              console.log('mandatorId');
        console.log(mandatorId);
             console.log('environment');
        console.log(environment);
         this.msg = 'Anmeldung erfolgreich durchgeführt.';
        this.$store.dispatch('login', {ident, token, mandatorId, environment });

        this.$router.push('/tour');
      } catch (error) {
        console.log(error);
        this.msg = 'Anmeldung fehlgeschlagen';
      }
    }
  },
  created()
  {
    this.selectedenvironment = this.environments[0];
  }
};
</script>
<style scoped>
body {font-family: Arial, Helvetica, sans-serif;}
form {border: 3px solid #f1f1f1;}
/* Bordered form */
form {
  border: 3px solid #f1f1f1;
}
/* Full-width inputs */
input[type=text], input[type=password] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}
/* Set a style for all buttons */
button {
  background-color: #031c3d;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
}
/* Add a hover effect for buttons */
button:hover {
  opacity: 0.8;
}
/* Add padding to containers */
.container {

padding-left: 560px;
  padding-right: 560px;
vertical-align: middle;
  
}
/* Full-width select */
select {
width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;

}
</style>
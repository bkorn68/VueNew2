<template>
  <div>
    <loading :active.sync="isLoading" 
        
        
        :is-full-page="fullPage"></loading>
    <h2>Tour</h2>
    <div class="container">
    <label for="uname"><b>Monteur</b></label>
    <select v-model="selectedTechnichian">
    <option v-bind:value="{name: technichian.name,sourceId: technichian.sourceId}" v-for="technichian in technichians">
      {{technichian.name + '[' + technichian.sourceId + ']' }}
      </option>

</select>


    <label for="psw"><b>Tag</b></label>
    <input type="date" v-model="selectedDate" />


    <button type="submit" @click="getTours">Touren</button>
    <p id="msg" v-if="msg">{{ msg }}</p>
    <TourList v-bind:tourList="tourList" v-if="this.toursfound" />
    <button type="submit" @click="showGoogle" v-if="this.toursfound" >Google</button>
    
    
  </div>
  
    
  </div>
</template>

<script>
import TOService from '@/services/TOService.js';
import TourList from "../components/TourList"
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';

    export default {
    data() {
    return {
      technichians: [
      ],
      //10925
      selectedTechnichian: {
          },
      
      selectedDate: '2020-10-01',
      msg: '',
      tourList: [],
      toursfound: false,
      googleURL: '',
      isLoading: false,
      fullPage: true
      
    }
  },
  components: {
    TourList,
    Loading
  },
  methods: {
      showLoader() {
                this.isLoading = true;
                // simulate AJAX
                // setTimeout(() => {
                //   this.isLoading = false
                // },5000)
            },
      async getTours()
        {
        try
        {
         this.toursfound = false;
         console.log("Start getTours")
         this.msg = 'Rufe Touren ab...';
         this.showLoader();
         const date = new Date(this.selectedDate);
         const jsonDate = date.toJSON();

      const request = {
           ident: this.$store.getters.getIdent,
           mandatorId: this.$store.getters.getMandatorId,
           technicianID: {
"IdentificationId":2,
      "DataSourceId":2,
      "DataTypeId":1016,
      "SourceId": this.selectedTechnichian.sourceId,
      "MandatorId": this.$store.getters.getMandatorId
           },
           date: jsonDate,
           environment: this.$store.getters.getEnvironment
         };
         console.log("Request:");
         console.log(request);
         const response = await TOService.getTours(request);
                  const tours = response;
         let count = tours.length;
         if (count > 0)
         {
         this.tourList = tours;
         this.toursfound = true;
         }
                 if(count == 0)
         {
        this.msg = 'keine Touren gefunden.';
        this.isLoading = false
         }
         else
         {
        this.msg = count + ' Touren gefunden.';
        this.isLoading = false
        }
 

        }
     catch(error)
    {
      console.log(error);
        this.msg = 'Abruf Touren fehlgeschlagen';
        this.isLoading = false
    }
     

      },
      showGoogle()
      {
        
        this.googleURL = 'https://www.google.de/maps/dir';
        this.tourList.forEach(tour => 
        {
          this.googleURL = this.googleURL + '/' + tour.geoLatitude + ',' + tour.geoLongitude;
        }
        
        );
        console.log('GoogleUrl:');
        console.log(this.googleURL);
        window.location.href = this.googleURL;
        
      }
  },
  async created() {
    
    try
    {
      console.log("Start getTechnicians")
      this.msg = 'Rufe Monteure ab...';
      this.showLoader();

      const request = {
           ident: this.$store.getters.getIdent,
           mandatorId: this.$store.getters.getMandatorId,
           environment: this.$store.getters.getEnvironment
         };
         console.log("Request:");
         console.log(request);
         
         const response = await TOService.getTechnicians(request);
         const techs = response;
         let count = techs.length;
         this.technichians = techs;
         if(count == 0)
         {
        this.msg = 'keine Monteuere gefunden.';
        this.isLoading = false
         }
         else
         {
        this.msg = count + ' Monteuere gefunden.';
        this.isLoading = false
        }
 
         
    }
    catch(error)
    {
      console.log(error);
        this.msg = 'Abruf Monteure fehlgeschlagen';
        this.isLoading = false
    }
    
  }
    }

</script>

<style scoped>
body {font-family: Arial, Helvetica, sans-serif;}
form {border: 3px solid #f1f1f1;}
/* Bordered form */
form {
  border: 3px solid #f1f1f1;
}
/* Full-width inputs */
input[type=text], input[type=date] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
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
</style>
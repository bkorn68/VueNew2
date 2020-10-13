
import axios from 'axios';


const techniciansUrl = '/api/Technicians';
const toursUrl = '/api/Tours';

export default {
    getTechnicians(request) {
    return axios
      .post(techniciansUrl, request)
      .then(response => response.data);
  },
  getTours(request) {
    return axios
      .post(toursUrl, request)
      .then(response => response.data);
  }

}

import axios from 'axios';


const loginUrl = '/api/Login';


export default {
  login(credentials) {
    return axios
      .post(loginUrl, credentials)
      .then(response => response.data);
  }
}
<template>
    <div>
      <h1>Register</h1>
      <form @submit.prevent="registrationHandler">
        <div>
          <label for="email">Email:</label>
          <input type="email" v-model="email" id="email" required />
        </div>
        <div>
          <label for="password">Password:</label>
          <input type="password" v-model="password" id="password" required />
        </div>
        <div>
          <label for="confirmPassword">Confirm Password:</label>
          <input type="password" v-model="confirmPassword" id="confirmPassword" required />
        </div>
        <button type="submit">Register</button>
      </form>
      <p v-if="errorMessage">{{ errorMessage }}</p>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import axios from 'axios';
  
  const email = ref('');
  const password = ref('');
  const confirmPassword = ref('');
  const errorMessage = ref('');
  
  async function registrationHandler() {
    if (password.value !== confirmPassword.value) {
      errorMessage.value = 'Passwords do not match.';
      return;
    }
    
    try {
      const response = await axios.post(
        'https://localhost:port/accounts/register',
        {
          email: email.value,
          password: password.value
        },
        {
          withCredentials: true
        }
      );
      console.log('Registration successful', response.data);
    } catch (error) {
      errorMessage.value = 'Registration failed. Please try again.';
      console.error(error);
    }
  }
  </script>
  

<style scoped>
.registration-container {
  max-width: 300px;
  margin: 0 auto;
  padding: 20px;
  text-align: center;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
  color: #ffffff;
}

input {
  width: 50%;
  padding: 8px;
  box-sizing: border-box;
}

button {
  padding: 10px 20px;
  background-color: #007bff;
  color: white;
  border: none;
  cursor: pointer;
}

p {
  color: red;
}
</style>
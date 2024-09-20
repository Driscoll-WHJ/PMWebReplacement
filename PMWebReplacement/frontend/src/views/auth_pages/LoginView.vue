<template>
    <div>
      <h1>Login</h1>
      <form @submit.prevent="loginHandler">
        <div>
          <label for="email">Email:</label>
          <input type="email" v-model="email" id="email" required />
        </div>
        <div>
          <label for="password">Password:</label>
          <input type="password" v-model="password" id="password" required />
        </div>
        <button type="submit">Login</button>
      </form>
      <p v-if="errorMessage">{{ errorMessage }}</p>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  import axios from 'axios';

  const email = ref('');
  const password = ref('');
  const errorMessage = ref('');
  const router=useRouter();
  
  async function loginHandler() {
    try {
      const response = await axios.post(
        'https://localhost:port/accounts/login', 
        {
          email: email.value,
          password: password.value
        },
        {
          withCredentials: true
        }
      );
  
      console.log('Login successful', response.data);
      router.push('/dashboard');
    } catch (error) {
      errorMessage.value = 'Login failed. Please check your credentials.';
      console.error(error);
      router.push('/dashboard') // Temporary
    }
  }
  </script>
  

  <style scoped>
.login-container {
  max-width: 400px;
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
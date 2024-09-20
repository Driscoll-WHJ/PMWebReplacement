<template>
    <div>
      <h1>Dashboard</h1>
    </div>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  const data = ref('');  
  
  // Function to fetch project data
  function getProjectData() {
    try {
        const response = axios.post(url);
        data = response;
    } catch(err){
        console.error(err);
    }
  }
  // Function called upon loading
  onMounted(() => {
    getProjectData();
  });
  </script>

import axios from 'axios';

// Get API base URL from environment or default to localhost
const getApiBaseUrl = () => {
  // Check if we're in GitHub Codespaces
  if (process.env.CODESPACE_NAME) {
    // In Codespaces, construct the backend URL
    const codespaceName = process.env.CODESPACE_NAME;
    return `https://${codespaceName}-5000.app.github.dev/api`;
  }
  
  // Check for custom environment variable
  if (process.env.REACT_APP_API_BASE_URL) {
    return process.env.REACT_APP_API_BASE_URL;
  }
  
  // Default to localhost for local development
  return 'http://localhost:5000/api';
};

const API_BASE_URL = getApiBaseUrl();

// Log the API base URL for debugging
console.log('API Base URL:', API_BASE_URL);
console.log('Environment:', process.env.NODE_ENV);
console.log('Codespace Name:', process.env.CODESPACE_NAME);

// Create axios instance with default config
const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor to add auth token
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Response interceptor to handle auth errors
api.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response?.status === 401) {
      // Token expired or invalid
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      window.location.href = '/login';
    }
    return Promise.reject(error);
  }
);

export default api;
import api from './api';

const expenseService = {
  // Get all expenses with optional filtering and pagination
  getExpenses: async (params = {}) => {
    try {
      const response = await api.get('/expense', { params });
      return response.data;
    } catch (error) {
      console.error('Error fetching expenses:', error);
      throw error;
    }
  },

  // Get a specific expense by ID
  getExpenseById: async (id) => {
    try {
      const response = await api.get(`/expense/${id}`);
      return response.data.expense;
    } catch (error) {
      console.error('Error fetching expense:', error);
      throw error;
    }
  },

  // Create a new expense
  createExpense: async (expenseData) => {
    try {
      const response = await api.post('/expense', expenseData);
      return response.data.expense;
    } catch (error) {
      console.error('Error creating expense:', error);
      throw error;
    }
  },

  // Update an existing expense
  updateExpense: async (id, expenseData) => {
    try {
      const response = await api.put(`/expense/${id}`, expenseData);
      return response.data.expense;
    } catch (error) {
      console.error('Error updating expense:', error);
      throw error;
    }
  },

  // Delete an expense
  deleteExpense: async (id) => {
    try {
      const response = await api.delete(`/expense/${id}`);
      return response.data;
    } catch (error) {
      console.error('Error deleting expense:', error);
      throw error;
    }
  },

  // Get available expense categories
  getCategories: async () => {
    try {
      const response = await api.get('/expense/categories');
      return response.data.categories;
    } catch (error) {
      console.error('Error fetching categories:', error);
      throw error;
    }
  }
};

export default expenseService;
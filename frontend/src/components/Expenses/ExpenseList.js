import React, { useState, useEffect } from 'react';
import expenseService from '../../services/expenseService';
import ExpenseItem from './ExpenseItem';
import Button from '../Common/Button';
import { getErrorMessage } from '../../utils/helpers';
import './Expenses.css';

const ExpenseList = ({ refreshTrigger, onEdit }) => {
  const [expenses, setExpenses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    fetchExpenses();
  }, [refreshTrigger]);

  const fetchExpenses = async () => {
    try {
      setLoading(true);
      setError('');
      const response = await expenseService.getExpenses();
      setExpenses(response.expenses || []);
    } catch (err) {
      setError(getErrorMessage(err));
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async (expenseId) => {
    if (!window.confirm('Are you sure you want to delete this expense?')) {
      return;
    }

    try {
      await expenseService.deleteExpense(expenseId);
      setExpenses(expenses.filter(expense => expense.id !== expenseId));
    } catch (err) {
      setError(getErrorMessage(err));
    }
  };

  if (loading) {
    return (
      <div className="expense-list__loading">
        <div className="spinner"></div>
        <span className="loading-text">Loading expenses...</span>
      </div>
    );
  }

  if (error) {
    return (
      <div className="expense-list__error">
        <div className="error-message">
          {error}
          <Button
            variant="outline"
            size="small"
            onClick={fetchExpenses}
            className="retry-btn"
          >
            Retry
          </Button>
        </div>
      </div>
    );
  }

  if (expenses.length === 0) {
    return (
      <div className="expense-list__empty">
        <div className="empty-state">
          <div className="empty-state__icon">📝</div>
          <h3 className="empty-state__title">No expenses yet</h3>
          <p className="empty-state__description">
            Start tracking your expenses by adding your first one above.
          </p>
        </div>
      </div>
    );
  }

  return (
    <div className="expense-list">
      <div className="expense-list__header">
        <h3 className="expense-list__title">
          Your Expenses ({expenses.length})
        </h3>
      </div>
      
      <div className="expense-grid">
        {expenses.map(expense => (
          <ExpenseItem
            key={expense.id}
            expense={expense}
            onDelete={handleDelete}
            onEdit={onEdit}
          />
        ))}
      </div>
    </div>
  );
};

export default ExpenseList;
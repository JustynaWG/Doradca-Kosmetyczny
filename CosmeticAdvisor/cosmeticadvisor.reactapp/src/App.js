import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import CustomerList from './components/CustomerList';
import CosmeticList from './components/CosmeticList';
import RecommendationList from './components/RecommendationList';

const App = () => {
  return (
      <Router>
        <div>
          <Routes>
            <Route path="/customers" element={<CustomerList />} />
            <Route path="/cosmetics" element={<CosmeticList />} />
            <Route path="/recommendations" element={<RecommendationList />} />
            <Route path="/" element={<h1>Home Page</h1>} />
          </Routes>
        </div>
      </Router>
  );
};

export default App;

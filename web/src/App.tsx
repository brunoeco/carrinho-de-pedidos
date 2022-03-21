import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { ThemeProvider } from 'styled-components';

import Footer from './components/Footer';
import Header from './components/Header';
import Cart from './pages/Cart';
import Favorites from './pages/Favorites';
import Home from './pages/Home';
import Login from './pages/Login';

import { lightTheme } from './themes';

function App() {
  return (
    <ThemeProvider theme={lightTheme}>
      <BrowserRouter>
        <Header />
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/cart' element={<Cart />} />
          <Route path='/login' element={<Login />} />
          <Route path='/favorites' element={<Favorites />} />
        </Routes>
        <Footer />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;

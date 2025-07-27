import React from 'react';
import './App.css';
import Home from './Components/Home';
import About from './Components/About';
import Contact from './Components/Contact';

function App() {
  return (
    <div className="App">
      <div style={{ 
        display: 'flex', 
        flexDirection: 'column', 
        justifyContent: 'center', 
        alignItems: 'center', 
        minHeight: '100vh',
        textAlign: 'center'
      }}>
        <Home />
        <About />
        <Contact />
      </div>
    </div>
  );
}

export default App;

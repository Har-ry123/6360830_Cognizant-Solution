// src/App.js
import React, { useState } from 'react';
import CurrencyConverter from './CurrencyConverter';

function App() {
  const [count, setCount] = useState(0);

  const increment = () => {
    sayHello();
    setCount(prev => prev + 1);
  };

  const decrement = () => {
    setCount(prev => prev - 1);
  };

  const sayHello = () => {
    alert("Hello! This is a static message.");
  };

  const sayWelcome = (msg) => {
    alert(`Message: ${msg}`);
  };

  const handleClick = (e) => {
    alert("I was clicked");
  };

  return (
    <div className="App">
      <h1>React Event Handling</h1>

      <h2>Counter: {count}</h2>
      <button onClick={increment}>Increment</button>
      <button onClick={decrement}>Decrement</button>

      <br /><br />
      <button onClick={() => sayWelcome("Welcome to React!")}>Say Welcome</button>

      <br /><br />
      <button onClick={(e) => handleClick(e)}>OnPress (Synthetic Event)</button>

      <br /><br />
      <CurrencyConverter />
    </div>
  );
}

export default App;

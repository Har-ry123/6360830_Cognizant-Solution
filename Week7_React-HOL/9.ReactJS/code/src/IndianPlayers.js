import React from 'react';

const oddPlayers = [
  { label: 'First', name: 'Sachin1' },
  { label: 'Third', name: 'Virat3' },
  { label: 'Fifth', name: 'Yuvraj5' },
];

const evenPlayers = [
  { label: 'Second', name: 'Dhoni2' },
  { label: 'Fourth', name: 'Rohit4' },
  { label: 'Sixth', name: 'Raina6' },
];

const mergedPlayers = [
  'Mr. First Player',
  'Mr. Second Player',
  'Mr. Third Player',
  'Mr. Fourth Player',
  'Mr. Fifth Player',
  'Mr. Sixth Player',
];

export default function IndianPlayers() {
  return (
    <div>
      <h2>Odd Players</h2>
      <ul>
        {oddPlayers.map((p, i) => (
          <li key={i}>{p.label}: {p.name}</li>
        ))}
      </ul>
      <h2>Even Players</h2>
      <ul>
        {evenPlayers.map((p, i) => (
          <li key={i}>{p.label}: {p.name}</li>
        ))}
      </ul>
      <h2>List of Indian Players Merged:</h2>
      <ul>
        {mergedPlayers.map((p, i) => (
          <li key={i}>{p}</li>
        ))}
      </ul>
    </div>
  );
}

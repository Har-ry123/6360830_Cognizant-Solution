import React from 'react';

function App() {
  // Data for List of Players
  const players = [
    { name: 'Mr. Jack', score: 50 },
    { name: 'Mr. Michael', score: 70 },
    { name: 'Mr. John', score: 40 },
    { name: 'Mr. Alan', score: 61 },
    { name: 'Mr. Elisabeth', score: 61 },
    { name: 'Mr. Siah', score: 95 },
    { name: 'Mr. Dhoni', score: 100 },
    { name: 'Mr. Virat', score: 104 },
    { name: 'Mr. Jadeja', score: 64 },
    { name: 'Mr. Raina', score: 75 },
    { name: 'Mr. Rohit', score: 80 },
  ];

  // Players with scores less than 70
  const playersBelow70 = players.filter(player => player.score < 70);

  // Odd/Even Players
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

  return (
    <div style={{ margin: '30px' }}>
      <h2>List of Players</h2>
      <ul>
        {players.map((player, idx) => (
          <li key={idx}>Mr. {player.name} {player.score}</li>
        ))}
      </ul>
      <hr />
      <h2>List of Players having Scores Less than 70</h2>
      <ul>
        {playersBelow70.map((player, idx) => (
          <li key={idx}>Mr. {player.name} {player.score}</li>
        ))}
      </ul>
      <hr />
      <div style={{ marginTop: '30px' }}>
        <div>When Flag=false</div>
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
    </div>
  );
}

export default App;     
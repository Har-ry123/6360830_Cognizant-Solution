import React from 'react';

const ListofPlayers = () => {
  const players = [
    { name: 'Virat Kohli', score: 85 },
    { name: 'Rohit Sharma', score: 45 },
    { name: 'KL Rahul', score: 95 },
    { name: 'Shreyas Iyer', score: 60 },
    { name: 'Rishabh Pant', score: 30 },
    { name: 'Hardik Pandya', score: 72 },
    { name: 'Ravindra Jadeja', score: 50 },
    { name: 'Bhuvneshwar Kumar', score: 40 },
    { name: 'Jasprit Bumrah', score: 15 },
    { name: 'Mohammed Shami', score: 25 },
    { name: 'Yuzvendra Chahal', score: 10 },
  ];

  const filteredPlayers = players.filter(player => player.score < 70);

  return (
    <div>
      <h2>Players with Scores Below 70</h2>
      <ul>
        {filteredPlayers.map((player, index) => (
          <li key={index}>{player.name} - {player.score}</li>
        ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;

import React from 'react';
import CohortDetails from './CohortDetails';
import './App.css';

function App() {
  const cohortsData = [
    {
      id: "INTADMDF10",
      name: "INTADMDF10 -.NET FSD",
      startDate: "22-Feb-2022",
      status: "Scheduled",
      coach: "Aathma",
      trainer: "Jojo Jose"
    },
    {
      id: "ADM21JF014",
      name: "ADM21JF014 -Java FSD",
      startDate: "10-Sep-2021",
      status: "Ongoing",
      coach: "Apoorv",
      trainer: "Elisa Smith"
    },
    {
      id: "CDBJF21025",
      name: "CDBJF21025 -Java FSD",
      startDate: "24-Dec-2021",
      status: "Ongoing",
      coach: "Aathma",
      trainer: "John Doe"
    }
  ];

  return (
    <div className="App">
      <div className="cohort-details-container">
        <h2>Cohorts Details</h2>
        <div className="cohort-cards">
          {cohortsData.map(cohort => (
            <CohortDetails key={cohort.id} cohort={cohort} />
          ))}
        </div>
      </div>
    </div>
  );
}

export default App;
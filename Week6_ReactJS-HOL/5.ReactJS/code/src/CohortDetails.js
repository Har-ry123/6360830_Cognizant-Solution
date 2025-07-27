import React from 'react';
import styles from './styles/CohortDetails.module.css';

const CohortDetails = ({ cohort }) => {
  // Define inline style for h3 based on cohort status
  const getHeadingStyle = (status) => {
    let color;
    if (status === 'Ongoing') {
      color = 'green';
    } else {
      color = 'blue';
    }
    
    return {
      color: color,
      margin: 0,
      marginBottom: '15px',
      fontSize: '16px',
      fontWeight: 'bold'
    };
  };

  return (
    <div className={styles.box}>
      <h3 style={getHeadingStyle(cohort.status)}>{cohort.name}</h3>
      
      <dl>
        <dt>Started On</dt>
        <dd>{cohort.startDate}</dd>
        
        <dt>Current Status</dt>
        <dd>{cohort.status}</dd>
        
        <dt>Coach</dt>
        <dd>{cohort.coach}</dd>
        
        <dt>Trainer</dt>
        <dd>{cohort.trainer}</dd>
      </dl>
    </div>
  );
};

export default CohortDetails;
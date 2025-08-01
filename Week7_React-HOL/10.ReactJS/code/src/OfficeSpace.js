import React from 'react';

// Use another realistic office image from Unsplash
const sr = "https://images.unsplash.com/photo-1515378791036-0648a3ef77b2?auto=format&fit=crop&w=600&q=80";
const ItemName = { Name: "DBS", Rent: 50000, Address: "Chennai" };

function OfficeSpace() {
  return (
    <div style={{ textAlign: 'center', marginTop: '40px' }}>
      <h1 style={{ fontWeight: 'bold' }}>Office Space , at Affordable Range</h1>
      <img src={sr} width="25%" height="25%" alt="Office Space" style={{ margin: '20px 0' }} />
      <div style={{ textAlign: 'left', display: 'inline-block', marginTop: '20px' }}>
        <h2><b>Name: {ItemName.Name}</b></h2>
        <h3 style={{ color: 'red', margin: 0 }}>Rent: Rs. {ItemName.Rent}</h3>
        <h3 style={{ margin: 0 }}>Address: {ItemName.Address}</h3>
      </div>
    </div>
  );
}

export default OfficeSpace;

import React from "react";
import "../Stylesheets/mystyle.css";

const CalculateScore = () => {
  return (
    <div style={{ textAlign: "center", marginTop: "50px" }}>
      <h1 style={{ color: "#8B0000", fontSize: "2.5rem", marginBottom: "30px", fontWeight: "bold" }}>
        Student Details:
      </h1>
      <div style={{ marginBottom: "10px" }}>
        <span style={{ fontWeight: "bold", color: "blue", fontSize: "1.2rem" }}>
          Name:
        </span>
        <span style={{ color: "brown", fontSize: "1.2rem" }}> Steeve</span>
      </div>
      <div style={{ marginBottom: "10px" }}>
        <span style={{ fontWeight: "bold", color: "#b30000", fontSize: "1.2rem" }}>
          School:
        </span>
        <span style={{ color: "#d87093", fontSize: "1.2rem" }}> DNV Public School</span>
      </div>
      <div style={{ marginBottom: "10px" }}>
        <span style={{ fontWeight: "bold", color: "#800000", fontSize: "1.2rem" }}>
          Total:
        </span>
        <span style={{ color: "brown", fontSize: "1.2rem" }}> 284Marks</span>
      </div>
      <div>
        <span style={{ fontWeight: "bold", color: "green", fontSize: "1.2rem" }}>
          Score:
        </span>
        <span style={{ color: "#228B22", fontSize: "1.2rem" }}>94.67%</span>
      </div>
    </div>
  );
};

export default CalculateScore;
// src/App.js
import React, { useState } from 'react';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';

function App() {
  const [section, setSection] = useState("book");

  return (
    <div className="App" style={{ display: 'flex', justifyContent: 'center', marginTop: '2em' }}>
      <div style={{ display: 'flex', width: '80%', justifyContent: 'space-between' }}>
        {/* Course Details */}
        <div style={{ flex: 1, textAlign: 'center' }}>
          <CourseDetails />
        </div>
        {/* Divider */}
        <div style={{ width: 3, background: 'green', margin: '0 2em' }} />
        {/* Book Details */}
        <div style={{ flex: 1, textAlign: 'center' }}>
          <BookDetails />
        </div>
        {/* Divider */}
        <div style={{ width: 3, background: 'green', margin: '0 2em' }} />
        {/* Blog Details */}
        <div style={{ flex: 1, textAlign: 'center' }}>
          <BlogDetails />
        </div>
      </div>
    </div>
  );
}

export default App;

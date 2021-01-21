import React, { useState } from 'react';
import './App.css';

function App() {
  const [data, setData] = useState<number[]>([]);
  const [lessThanOrEqualTo, setLessThanOrEqualTo] = useState('');
  const [pageSize, setPageSize] = useState('10');
  const [page, setPage] = useState(1);

  const handleSubmit = async (pageToRequest: number) => {
    const response = await fetch(`https://localhost:49165/Primes/LessThanOrEqualTo/${lessThanOrEqualTo}?page=${pageToRequest}&perPage=${pageSize}`);
    setData(await response.json());
  }

  const nextPage = () => {
    handleSubmit(page + 1);
    setPage(prev => prev + 1);
  }

  const previousPage = () => {
    handleSubmit(page - 1);
    setPage(prev => prev - 1);
  }
  
  return (
    <div className="App">
      <form onSubmit={(e) => { 
        e.preventDefault();
        setPage(1);
        handleSubmit(1);
        }}>
        <label>Less than or equal to: <input type="number" value={lessThanOrEqualTo} onChange={e => setLessThanOrEqualTo(e.target.value)} /></label>
        <label>Results per page: <input type="number" value={pageSize} onChange={e => setPageSize(e.target.value)} /></label>
        <button type="submit">Get Results</button>
      </form>
      {data.map(d => <div key={d}>{d}</div>)}
      <div>
        {page > 1 && <button onClick={previousPage}>Previous Page</button>}
        <button onClick={nextPage}>Next Page</button>
      </div>
    </div>
  );
}

export default App;

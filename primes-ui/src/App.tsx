import React, { useState } from 'react';
import styled from 'styled-components';
import './App.css';

const Container = styled.div`
  max-width: 90%;
  width: 600px;
  margin: 20px auto;
`;

const MainForm = styled.form`
  background-color: #f7f7f7;
  padding 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const FormField = styled.label`
  padding: 5px 10px;
  margin-bottom: 10px;
`;

const Input = styled.input`
  color: #555;
  border: 1px solid #efefef;
  padding: 10px;
`

const ColoredButton = styled.button`
  width: 160px;
  padding: 5px 10px;
  text-align: center;
  background-color: #0071ED;
  color: #fff;
  border: none;
`;

const Pagination = styled.div`
  display: flex;
  justify-content: space-between;
  margin: 10px 0;
  padding: 0 20px;
`;

const ResultContainer = styled.div`
  padding: 10px;
`

const Result = styled.div`
  padding: 5px;
  border-bottom: 1px solid #efefef;
  &:last-child {
    border-bottom: none;
  }
`;

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
    <Container className="App">
      <MainForm onSubmit={(e) => { 
        e.preventDefault();
        setPage(1);
        handleSubmit(1);
        }}>
        <FormField>Less than or equal to: <Input type="number" value={lessThanOrEqualTo} onChange={e => setLessThanOrEqualTo(e.target.value)} /></FormField>
        <FormField>Results per page: <Input type="number" value={pageSize} onChange={e => setPageSize(e.target.value)} /></FormField>
        <ColoredButton type="submit">Get Results</ColoredButton>
      </MainForm>
      <ResultContainer>
        {data.map(d => <Result key={d}>{d}</Result>)}
      </ResultContainer>
      <Pagination>
        {page > 1 ? <ColoredButton onClick={previousPage}>Previous Page</ColoredButton> : <div></div>}
        {data.length > 0 ? <ColoredButton onClick={nextPage}>Next Page</ColoredButton> : <div></div>}
      </Pagination>
    </Container>
  );
}

export default App;

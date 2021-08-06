import logo from './logo.svg';
import { useState } from "react"; //ok
import './App.css';
import Board from './Componentes/Tabla/Tabla';
import Square from './Componentes/Squares/Squares';


const winningPositions= [
  [0, 1, 2],
  [3 ,4, 5],
  [6, 7, 8],
  [0, 3, 6],
  [1, 4, 7],
  [2, 5, 8],
  [0, 4, 8],
  [2, 4, 6],
];

const App = () => {
  const [turn, setTurn] = useState('x'); //ok
  const [squares, setSquares] = useState(Array(9).fill(null));//ok
  const [winningSquares, setWinningSquares]= useState([]);
  const [score, setScore] = useState({
    o: 0,
    x: 0,
  });//ok

  const reset =() => {
    setTurn('o');
    setSquares(Array(9).fill(null))
    setWinningSquares([]);
  }

  const checkForWinner = newSquares =>{
    for(let i = 0; i < winningPositions.length; i++){
      const[a,b,c] = winningPositions[i];
      if(newSquares[a] && newSquares[a] === newSquares[b] && newSquares[a] === newSquares[c])
      endGame(newSquares[a],winningPositions[i]);

      return
    }
  
    if(!newSquares.includes(null)){
      endGame(null, Array.from(Array(10).keys()));
      return
    }

    setTurn(turn === 'o'? 'x': 'o');
  }

  const handClick = square => {

    let newSquares = [...squares];
    newSquares.splice(square, 1, turn);
    setSquares(newSquares);
    checkForWinner(newSquares);
  }

  const endGame = (result, winningPositions) => {
    setTurn(null);
    if(result !== null) {
      setScore({
        ...score, 
        [result]: score[result] +1,
      })
    }
    setWinningSquares(winningPositions);
    setTimeout(() =>{
    reset();
  }, 3000);

  }

  return (
    <div className="container">
      <Board winningSquares={winningSquares} turn={turn} squares={squares} onClick={handClick}/>
      
    </div>
  );
}

export default App;

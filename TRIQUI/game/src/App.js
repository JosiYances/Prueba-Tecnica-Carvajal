import logo from './logo.svg';
import { useState } from "react";
import './App.css';
import Board from './Componentes/Tabla/Tabla';
import Square from './Componentes/Squares/Squares';
import ScoreBoard from './Componentes/Scoreboard/Scoreboard';

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
  const [turn, setTurn] = useState('x');
  const [squares, setSquares] = useState(Array(9).fill(null));
  const [winningSquares, setWinningSquares]= useState([]);
  const [score, serScore] = useState({
    o: 0,
    x: 0,
  });

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
      endGame(null,Array.from(Array(10).keys()));
      return
    }

    setTurn(turn === 'o'? 'x': 'o');
  }

  const handClick = Square =>{

    let newSquares = [...squares];
    newSquares.splice(Square, 1, turn);
    setSquares(newSquares);
    checkForWinner(newSquares);
  }

  const endGame = (result, winningPositions) =>{
    setTurn(null);
    if(result!=null){
      setSquares({
        ...score, 
        [result]:score[result]+1,
      })
    }
    setWinningSquares(winningPositions);
    setTimeout(() =>{
    reset();
  }, 3000);

  }

  return (
    <div className="Container">
      <Tabla winningSquares={winningSquares} turn={turn} squeares={squares} onClick={handClick}/>
      <ScoreBoard scoreo={score.o} scorex={score.x}/>
    </div>
  );
}

export default App;

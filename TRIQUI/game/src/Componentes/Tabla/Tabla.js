import Square from "../Squares/Squares";
import './Board.css'


const Board = ({Square, onClick, turn, winningSquares }) => {

    const createSquares = value => (
        values.map( values =>(
            <Square
            winner={winningSquares.includes(value)}
            turn = {turn}
            onClick={() => onClick(value)}
            value ={value}
            key={`square_ ${value}`}
            />
        )));
        
    return(
        <div className="board">
            <div className="row">
                {createSquares([0,1,2])}
            </div>
            <div className="row">
                {createSquares([3,4,5])}    
            </div>
            <div className="row">
                {createSquares([6,7,8])}
            </div>

        </div>
    );

}
export default Board;
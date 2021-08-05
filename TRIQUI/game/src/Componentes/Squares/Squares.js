import './Square.css';
import className from 'classnames';



const Square =({ value, onClick, turn, winner }) => {

    const handleClick =() => {
        turn !== null && value === null && onClick();
    }
    
    let squareClass = className({
        Square: true,
        [`square--${value}`]: value!==null,
        winner: winner,
    })


    return (
        <div className ={squareClass} onClick={() => handleClick()}>

        </div>
    )
}
export default Square;
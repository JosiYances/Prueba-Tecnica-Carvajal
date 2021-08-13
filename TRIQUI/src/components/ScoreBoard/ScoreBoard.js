import './ScoreBoard.css';

const ScoreBoard = ({scorex, scoreo}) => (
    <div className="score-board">
        <div>{scorex}</div>
        <div>{scoreo}</div>
    </div>
)

export default ScoreBoard;
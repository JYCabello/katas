namespace GameOfLife;

public class World
{
    private Board board;

    public World(bool[,] board) =>
        this.board = new Board(board);

    public Board NextState()
    {
        var newBoard = new bool[board.Height, board.Width];

        for (var y = 0; y < board.Height; y++)
        for (var x = 0; x < board.Width; x++)
            newBoard[y, x] = WillBeAlive(y, x);

        board = new Board(newBoard);
        return board;
    }

    public bool WillBeAlive(int y, int x)
    {
        var neighbors = board.GetNeighbors(y, x);

        var livingNeighbors = neighbors.Count(b => b);

        if (!board.IsAlive(y, x))
            return livingNeighbors == 3;

        return livingNeighbors is < 4 and > 1;
    }
}

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
            newBoard[y, x] = WillBeAlive(x, y);

        board = new Board(newBoard);
        return board;
    }

    public bool WillBeAlive(int x, int y)
    {
        var neighbors = board.GetNeighbors(y, x);

        var count = 0;
        foreach (var neighbor in neighbors)
            if (neighbor)
                count++;

        if (!board.IsAlive(y, x))
            return count == 3;

        return count is < 4 and > 1;
    }
}

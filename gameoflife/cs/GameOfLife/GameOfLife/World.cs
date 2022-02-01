namespace GameOfLife;

public class World
{
    private readonly Board board2;

    public World(bool[,] board) =>
        board2 = new Board(board);

    public Board NextState()
    {
        var newBoard = new bool[board2.Height, board2.Width];

        for (var y = 0; y < board2.Height; y++)
        for (var x = 0; x < board2.Width; x++)
            newBoard[y, x] = WillBeAlive(x, y);

        return new Board(newBoard);
    }

    public bool WillBeAlive(int x, int y)
    {
        var neighbors = board2.GetNeighbors(y, x);

        var count = 0;
        foreach (var neighbor in neighbors)
            if (neighbor)
                count++;

        if (!board2.IsAlive(y, x))
            return count == 3;

        return count is < 4 and > 1;
    }
}

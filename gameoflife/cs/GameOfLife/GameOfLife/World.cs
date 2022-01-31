namespace GameOfLife;

public class World
{
    private readonly bool[][] board;

    public World(bool[][] board) =>
        this.board = board;

    public bool[][] NextState()
    {
        var newBoardHeight = board.Length;
        var newBoardWidth = board[0].Length;

        var newBoard = new bool[newBoardHeight][];
        for (var y = 0; y < newBoardHeight; y++)
        {
            newBoard[y] = new bool[newBoardWidth];
        }

        for (var y = 0; y < newBoardHeight; y++)
        {
            for (var x = 0; x < newBoardWidth; x++)
            {
                newBoard[y][x] = WillBeAlive(x, y);
            }
        }

        return newBoard;
    }

    public bool[] GetNeighbors(int x, int y)
    {
        var neigbors = new List<bool>();

        if (x > 0 && y > 0)
            neigbors.Add(board[y - 1][x - 1]);

        if (y > 0)
            neigbors.Add(board[y - 1][x]);

        if (y > 0 && board[y - 1].Length > x + 1)
            neigbors.Add(board[y - 1][x + 1]);

        if (board[y].Length > x + 1)
            neigbors.Add(board[y][x + 1]);

        if (board.Length > y + 1 && board[y].Length > x + 1)
            neigbors.Add(board[y + 1][x + 1]);

        if (board.Length > y + 1)
            neigbors.Add(board[y + 1][x]);

        if (board.Length > y + 1 && x > 0)
            neigbors.Add(board[y + 1][x - 1]);

        if (x > 0)
            neigbors.Add(board[y][x - 1]);

        return neigbors.ToArray();
    }

    public bool WillBeAlive(int x, int y)
    {
        var neighbors = GetNeighbors(x, y);

        var count = 0;
        foreach (var neighbor in neighbors)
            if (neighbor)
                count++;

        return count is < 4 and > 1;
    }
}

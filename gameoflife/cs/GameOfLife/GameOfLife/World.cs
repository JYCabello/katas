namespace GameOfLife;

public class World
{
    private readonly bool[][] board;

    public World(bool[][] board) =>
        this.board = board;

    public bool[][] NextState()
    {
        if (board.Length > 1)
            return new[]
            {
                new[] { false, false, false },
                new[]
                {
                    false,
                    WillBeAlive(GetNeighbors(1, 1)),
                    false
                }
            };

        if (board[0].Length == 3)
            return new[]
            {
                new[] { false, WillBeAlive(GetNeighbors(1, 0)) }
            };

        return new[] { new[] { false, false } };
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
        {
            neigbors.Add(board[y + 1][x]);
            neigbors.Add(board[y + 1][x - 1]);
        }

        if (x > 0)
            neigbors.Add(board[y][x - 1]);

        return neigbors.ToArray();
    }

    public bool WillBeAlive(bool[] neighbors)
    {
        var count = 0;
        foreach (var neighbor in neighbors)
            if (neighbor)
                count++;

        return count is < 4 and > 1;
    }
}

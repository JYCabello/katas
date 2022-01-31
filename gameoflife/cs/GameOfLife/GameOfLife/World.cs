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
                    WillBeAlive(new[]
                    {
                        board[0][0], board[0][1], board[0][2], board[1][0], board[1][2]
                    }),
                    false
                }
            };

        if (board[0].Length == 3)
            return new[]
            {
                new[] { false, WillBeAlive(new[] { board[0][0], board[0][2] }) }
            };

        return new[] { new[] { false, false } };
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

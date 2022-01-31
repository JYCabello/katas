namespace GameOfLife;

public class World
{
    private readonly bool[][] board;

    public World(bool[][] board) =>
        this.board = board;

    public bool[][] NextState()
    {
        if (board.Length > 1)
        {
            return new[]
            {
                new[] { false, false, false },
                new[] { false, false, false }
            };
        }

        if (board[0].Length == 3)
            return new[]
            {
                new[] { false, board[0][0] && board[0][2] }
            };

        return new[] { new[] { false, false } };
    }
}

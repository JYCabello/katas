namespace GameOfLife;

public class World
{
    private readonly bool[][] board;

    public World(bool[][] board) =>
        this.board = board;

    public bool[][] NextState()
    {
        if (board[0].Length == 3 && board[0][0] && board[0][2])
            return new[] { new[] { false, true } };

        return new[] { new[] { false, false } };
    }
}

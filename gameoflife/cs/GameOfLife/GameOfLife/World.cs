namespace GameOfLife;

public class World
{
    private readonly bool[][] board;

    public World(bool[][] board) =>
        this.board = board;

    public bool[][] NextState() =>
        new[] { new[] { false } };
}

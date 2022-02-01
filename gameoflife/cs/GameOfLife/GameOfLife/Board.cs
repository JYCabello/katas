namespace GameOfLife;

public class Board
{
    private readonly bool[,] board;

    public Board(bool[,] board) =>
        this.board = board;

    public bool[] GetNeighbors(int x, int y)
    {
        var neigbors = new List<bool>();



        return neigbors.ToArray();
    }
}

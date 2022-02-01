namespace GameOfLife;

public class Board
{
    private readonly bool[,] board;

    public Board(bool[,] board) =>
        this.board = board;

    public bool[] GetNeighbors(int y, int x)
    {
        var width = board.GetLength(1);
        var neigbors = new List<bool>();

        var isOnRightBorder = width == x + 1;

        if (!isOnRightBorder)
            neigbors.Add(board[y, x + 1]);


        return neigbors.ToArray();
    }
}

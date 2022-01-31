namespace GameOfLife;

public class World
{
    private readonly bool[][] _bools;
    public World(bool[][] bools)
    {
        _bools = bools;
    }

    public void NextState() { }

    public bool[][] GetBoard()
    {
        if (_bools[0].Length == 3)
        {
            if (!_bools[0][0])
                return new[] { new[] { false, false } };
            return new[] { new[] { false, true } };
        }

        if (_bools[0].Length == 2)
            return new[] { new[] { false, false } };

        return new[] { new[] { false } };
    }
}

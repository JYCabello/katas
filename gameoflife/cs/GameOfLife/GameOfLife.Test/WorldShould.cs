using Xunit;

namespace GameOfLife.Test;

public class WorldShould
{
    [Fact(DisplayName = "kill a single cell")]
    public void Test1()
    {
        var world = new World(new [,] 
        {
            { true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(0, 0));
    }

    [Fact(DisplayName = "kill an isolated cell")]
    public void Test2()
    {
        var world = new World(new [,] 
        {
            { true, true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(0, 1));
    }

    [Fact(DisplayName = "kill an isolated cell in a longer row")]
    public void Test3()
    {
        var world = new World(new [,] 
        {
            { false, true, false }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(0, 1));
    }

    [Fact(DisplayName = "keep a sustained cell in a longer row alive")]
    public void Test4()
    {
        var world = new World(new [,] 
        {
            { true, true, true }
        });
        var result = world.NextState();
        Assert.True(result.IsAlive(0, 1));
    }

    [Fact(DisplayName = "kill an isolated cell in a longer row with a dead neighbor")]
    public void Test5()
    {
        var world = new World(new [,] 
        {
            { true, true, false }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(0, 1));
    }

    [Fact(DisplayName = "kill an isolated cell in a second row with no living neighbors")]
    public void Test6()
    {
        var world = new World(new [,] 
        {
            { false, false, false },
            { false, true, false }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(1, 1));
    }

    [Fact(DisplayName = "keep alive a sustained cell in a second row")]
    public void Test7()
    {
        var world = new World(new [,] 
        {
            { false, true, false },
            { false, true, true }
        });
        var result = world.NextState();
        Assert.True(result.IsAlive(1, 1));
    }

    [Fact(DisplayName = "kills an overpopulated cell in a second row")]
    public void Test8()
    {
        var world = new World(new [,] 
        {
            { false, true, true },
            { true, true, true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(1, 1));
    }

    [Fact(DisplayName = "kills an overpopulated cell in a second row counting on the third")]
    public void Test9()
    {
        var world = new World(new [,] 
        {
            { false, false, false },
            { true, true, false },
            { true, true, true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(1, 1));
    }

    [Fact(DisplayName = "kills an overpopulated cell in the third row")]
    public void Test10()
    {
        var world = new World(new [,] 
        {
            { false, false, false },
            { true, true, false },
            { true, true, true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(2, 1));
    }

    [Fact(DisplayName = "reproduces with exactly three living neighbors")]
    public void Test11()
    {
        var world = new World(new [,] 
        {
            { false, false, false },
            { true, false, false },
            { true, false, true }
        });
        var result = world.NextState();
        Assert.True(result.IsAlive(1, 1));
    }

    [Fact(DisplayName = "does not reproduce with exactly two living neighbors")]
    public void Test12()
    {
        var world = new World(new [,] 
        {
            { false, false, false },
            { true, false, false },
            { false, false, true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(1, 1));
    }

    [Fact(DisplayName = "keeps history")]
    public void Test13()
    {
        var world = new World(new [,]
        {
            { true, false, true, false, false },
            { false, true, false, false, false },
            { true, false, true, false, false },
            { false, false, false, true, false },
            { false, false, false, false, true }
        });
        var result = world.NextState();
        Assert.False(result.IsAlive(1, 1));
        Assert.False(result.IsAlive(3, 2));
        var secondResult = world.NextState();
        Assert.True(secondResult.IsAlive(3, 2));
    }
}

using Xunit;

namespace GameOfLife.Test;

public class WorldShould
{
    [Fact(DisplayName = "kill a single cell")]
    public void Test1()
    {
        var world = new World(new []
        {
            new [] { true }
        });
        var result = world.NextState();
        Assert.False(result[0][0]);
    }

    [Fact(DisplayName = "kill an isolated cell")]
    public void Test2()
    {
        var world = new World(new []
        {
            new [] { true, true }
        });
        var result = world.NextState();
        Assert.False(result[0][1]);
    }

    [Fact(DisplayName = "kill an isolated cell in a longer row")]
    public void Test3()
    {
        var world = new World(new []
        {
            new [] { false, true, false }
        });
        var result = world.NextState();
        Assert.False(result[0][1]);
    }

    [Fact(DisplayName = "keep a sustained cell in a longer row alive")]
    public void Test4()
    {
        var world = new World(new []
        {
            new [] { true, true, true }
        });
        var result = world.NextState();
        Assert.True(result[0][1]);
    }

    [Fact(DisplayName = "kill an isolated cell in a longer row with a dead neighbor")]
    public void Test5()
    {
        var world = new World(new []
        {
            new [] { true, true, false }
        });
        var result = world.NextState();
        Assert.False(result[0][1]);
    }

    [Fact(DisplayName = "kill an isolated cell in a second row with no living neighbors")]
    public void Test6()
    {
        var world = new World(new []
        {
            new [] { false, false, false },
            new [] { false, true, false }
        });
        var result = world.NextState();
        Assert.False(result[1][1]);
    }

    [Fact(DisplayName = "keep alive a sustained cell in a second row")]
    public void Test7()
    {
        var world = new World(new []
        {
            new [] { false, true, false },
            new [] { false, true, true }
        });
        var result = world.NextState();
        Assert.True(result[1][1]);
    }

    [Fact(DisplayName = "kills an overpopulated cell in a second row")]
    public void Test8()
    {
        var world = new World(new []
        {
            new [] { false, true, true },
            new [] { true, true, true }
        });
        var result = world.NextState();
        Assert.False(result[1][1]);
    }

    [Fact(DisplayName = "kills an overpopulated cell in a second row counting on the third")]
    public void Test9()
    {
        var world = new World(new []
        {
            new [] { false, false, false },
            new [] { true, true, false },
            new [] { true, true, true }
        });
        var result = world.NextState();
        Assert.False(result[1][1]);
    }

    [Fact(DisplayName = "kills an overpopulated cell in the third row")]
    public void Test10()
    {
        var world = new World(new []
        {
            new [] { false, false, false },
            new [] { true, true, false },
            new [] { true, true, true }
        });
        var result = world.NextState();
        Assert.False(result[2][1]);
    }

}

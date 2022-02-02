// See https://aka.ms/new-console-template for more information

using GameOfLife;

var world = new World(new [,]
{
    { true, false, true, false, false },
    { false, true, false, false, false },
    { true, false, true, false, false },
    { false, false, false, true, false },
    { false, false, false, false, true }
});

void Render(Board board)
{
    for (var y = 0; y < board.Height; y++)
    {
        for (var x = 0; x < board.Width; x++)
            Console.Write(board.IsAlive(x, y) ? "██" : "  ");

        Console.WriteLine();
    }
}

while (true)
{
    world.Process(Render);
    Thread.Sleep(1000);
    Console.Clear();
    world.NextState();
}

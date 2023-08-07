using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int consoleWidth = 30;
    static int consoleHeight = 20;
    static int spaceshipX = consoleWidth / 2;
    static int spaceshipY = consoleHeight - 1;
    static List<int> asteroidX = new List<int>();
    static List<int> asteroidY = new List<int>();
    static Random random = new Random();
    static bool isGameOver = false;

    static void Main(string[] args)
    {
        Console.Title = "Space Game";
        Console.CursorVisible = false;
        Console.SetWindowSize(consoleWidth, consoleHeight);
        Console.SetBufferSize(consoleWidth, consoleHeight);

        Thread asteroidThread = new Thread(new ThreadStart(GenerateAsteroids));
        asteroidThread.Start();

        while (!isGameOver)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                MoveSpaceship(key.Key);
            }

            DrawSpaceship();
            DrawAsteroids();
            CheckCollision();

            Thread.Sleep(20);
            Console.Clear();
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.ReadLine();
    }

    static void MoveSpaceship(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (spaceshipX > 0)
                    spaceshipX--;
                break;
            case ConsoleKey.RightArrow:
                if (spaceshipX < consoleWidth - 1)
                    spaceshipX++;
                break;
        }
    }

    static void GenerateAsteroids()
    {
        while (!isGameOver)
        {
            int newX = random.Next(0, consoleWidth);
            int newY = 0;
            asteroidX.Add(newX);
            asteroidY.Add(newY);
            Thread.Sleep(200);
        }
    }

    static void DrawSpaceship()
    {
        Console.SetCursorPosition(spaceshipX, spaceshipY);
        Console.Write("^");
    }

    static void DrawAsteroids()
    {
        for (int i = 0; i < asteroidX.Count; i++)
        {
            Console.SetCursorPosition(asteroidX[i], asteroidY[i]);
            Console.Write("*");
            asteroidY[i]++;

            if (asteroidY[i] == consoleHeight)
            {
                asteroidX.RemoveAt(i);
                asteroidY.RemoveAt(i);
                i--;
            }
        }
    }

    static void CheckCollision()
    {
        for (int i = 0; i < asteroidX.Count; i++)
        {
            if (asteroidX[i] == spaceshipX && asteroidY[i] == spaceshipY)
            {
                isGameOver = true;
                break;
            }
        }
    }

}

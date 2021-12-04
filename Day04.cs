using System;
using Util;
using System.Collections.Generic;
using System.Linq;

namespace Day04
{
    class Board
    {
        public List<(int number, bool isMarked)> Numbers { get; } = new List<(int number, bool isMarked)>();
        public bool HasWon { get; private set; } = false;

        int size;

        public Board(int boardSize = 5)
        {
            size = boardSize;
        }
        (int, int) GetIndex(int number)
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (Numbers[x + y * size].number == number) return (x, y);
                }
            }
            return (-1, -1);
        }
        bool CheckHorizontal(int y)
        {
            for (int x = 0; x < size; x++)
            {
                if (!Numbers[x + y * size].isMarked) return false;
            }
            return true;

        }
        bool CheckVertical(int x)
        {
            for (int y = 0; y < size; y++)
            {
                if (!Numbers[x + y * size].isMarked) return false;
            }
            return true;
        }
        public void Check(int number)
        {
            if (HasWon) return;

            (int x, int y) index = GetIndex(number);

            if (index.x == -1) return;

            Numbers[index.x + index.y * size] = (number, true);
            HasWon = CheckHorizontal(index.y) || CheckVertical(index.x);
        }
        public int SumUncheckedNumbers()
        {
            int sum = 0;
            foreach (var field in Numbers)
            {
                if (!field.isMarked) sum += field.number;
            }
            return sum;
        }
    }

    class Day04
    {

        static void Main(string[] args)
        {
            string[] input = Data.ToStringArray("D:/AoC/Data/04.txt");

            int[] draws = input[0].Split(',').Select(x => int.Parse(x)).ToArray();

            List<Board> boards = new List<Board>() { new Board() };
            for (int i = 2; i < input.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    boards.Add(new Board());
                    continue;
                }
                boards.Last().Numbers.AddRange(input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => (int.Parse(x), false)).ToArray());
            }

            Console.WriteLine(Part01(boards, draws));
            Console.WriteLine(Part02(boards, draws));
        }

        static int Part01(List<Board> boards, int[] draws)
        {
            for (int draw = 0; draw < draws.Length; draw++)
            {
                for (int board = 0; board < boards.Count; board++)
                {
                    boards[board].Check(draws[draw]);

                    if (boards[board].HasWon)
                    {
                        return boards[board].SumUncheckedNumbers() * draws[draw];
                    }

                }
            }
            return 0;
        }

        static int Part02(List<Board> boards, int[] draws)
        {
            int lastWinningBoard = -1;
            int lastWinningDraw = -1;

            for (int draw = 0; draw < draws.Length; draw++)
            {
                for (int board = 0; board < boards.Count; board++)
                {
                    if (boards[board].HasWon) continue;

                    boards[board].Check(draws[draw]);

                    if (boards[board].HasWon)
                    {
                        lastWinningBoard = board;
                        lastWinningDraw = draw;
                    }

                }
            }
            return boards[lastWinningBoard].SumUncheckedNumbers() * draws[lastWinningDraw];
        }
    }
}

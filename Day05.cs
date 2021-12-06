using System;
using System.Linq;
using System.Collections.Generic;
using Util;

namespace Day05
{
    class Day05
    {
        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public Point(int[] xy)
            {
                this.x = xy[0];
                this.y = xy[1];
            }
        }
        struct Line
        {
            public Point a;
            public Point b;

            public bool IsHorizontal => a.x == b.x;
            public bool IsVertical => a.y == b.y;
            public bool IsOrthogonal => IsHorizontal || IsVertical;

            public List<Point> AsPoints()
            {
                List<Point> points = new List<Point>();

                int dx = Math.Abs(a.x - b.x);
                int dy = Math.Abs(a.y - b.y);
                int dirX = a.x < b.x ? 1 : -1;
                int dirY = a.y < b.y ? 1 : -1;

                if (IsHorizontal)
                {
                    for (int i = 0; i <= dy; i++)
                    {
                        points.Add(new Point(a.x, a.y + i * dirY));
                    }
                }
                else if (IsVertical)
                {
                    for (int i = 0; i <= dx; i++)
                    {
                        points.Add(new Point(a.x + i * dirX, a.y));
                    }
                }
                else
                {
                    for (int x = 0; x <= dx; x++)
                    {
                        points.Add(new Point(a.x + x * dirX, a.y + x * dirY));
                    }
                }

                return points;
            }
        }

        static void Main(string[] args)
        {
            string[] input = Data.ToStringArray("D:/AoC/Data/05.txt");

            List<Line> lines = new List<Line>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] splitInput = input[i].Split(" -> ");

                lines.Add(
                    new Line() {
                        a = new Point(splitInput[0].Split(",").Select(x => int.Parse(x)).ToArray()),
                        b = new Point(splitInput[1].Split(",").Select(x => int.Parse(x)).ToArray())
                    }
                    );
            }

            Console.WriteLine(Part01(lines));
            Console.WriteLine(Part02(lines));

        }

        static int[] CreateMap(List<Line> lines, int size, bool ignoreDiagnoalLines = false)
        {
            int[] map = new int[size * size];

            for (int i = 0; i < lines.Count; i++)
            {
                if (ignoreDiagnoalLines && !lines[i].IsOrthogonal) continue;
                foreach (Point point in lines[i].AsPoints())
                {
                    map[point.x + point.y * size]++;
                }
            }
            return map;
        }

        static int Part01(List<Line> lines)
        {
            return CreateMap(lines, 1000, true).Where(x => x >= 2).Count();
        }
        static int Part02(List<Line> lines)
        {
            return CreateMap(lines, 1000).Where(x => x >= 2).Count();
        }
    }
}

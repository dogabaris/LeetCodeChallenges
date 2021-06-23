using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = {new []{2,1,1},new []{1,1,0},new []{0,1,1}};
            var res = OrangesRotting(grid);
            Console.WriteLine(res);
        }

        private static int OrangesRotting(int[][] grid) {
            if(grid.Count() == 1 && grid[0].Count() == 1){
                if(grid[0][0] == 1){
                    return -1;
                }
                else {
                    return 0;
                }
            }
        
            var rottensQueue = new List<RottenOrange>();
            var notRottenCount = 0;
            int result = 0;
            int wave = 0;
            
            for(var i=0;i<grid.Length;i++){
                for(var j=0;j<grid[0].Length;j++){
                    if(grid[i][j] == 2) {
                        rottensQueue.Add(new RottenOrange(i,j, wave));
                    }
                    if(grid[i][j] == 1) notRottenCount += 1; 
                }
            }
            
            while (rottensQueue.Count>0)
            {
                var rottenOrange = rottensQueue.First();
                rottensQueue.RemoveAt(0);
                
                if (grid.ElementAtOrDefault(rottenOrange.Left.i) != null && grid[rottenOrange.Left.i].ElementAtOrDefault(rottenOrange.Left.j) != 0 && grid[rottenOrange.Left.i][rottenOrange.Left.j] == 1)
                {
                    grid[rottenOrange.Left.i][rottenOrange.Left.j] = 2;
                    rottensQueue.Add(new RottenOrange(rottenOrange.Left.i,rottenOrange.Left.j,rottenOrange.Wave + 1));
                    notRottenCount--;
                }
                
                if (grid.ElementAtOrDefault(rottenOrange.Up.i) != null && grid[rottenOrange.Up.i].ElementAtOrDefault(rottenOrange.Up.j) != 0 && grid[rottenOrange.Up.i][rottenOrange.Up.j] == 1)
                {
                    grid[rottenOrange.Up.i][rottenOrange.Up.j] = 2;
                    rottensQueue.Add(new RottenOrange(rottenOrange.Up.i,rottenOrange.Up.j, rottenOrange.Wave + 1));
                    notRottenCount--;
                }
                
                if (grid.ElementAtOrDefault(rottenOrange.Right.i) != null && grid[rottenOrange.Right.i].ElementAtOrDefault(rottenOrange.Right.j) != 0 && grid[rottenOrange.Right.i][rottenOrange.Right.j] == 1)
                {
                    grid[rottenOrange.Right.i][rottenOrange.Right.j] = 2;
                    rottensQueue.Add(new RottenOrange(rottenOrange.Right.i,rottenOrange.Right.j, rottenOrange.Wave + 1));
                    notRottenCount--;
                }
                
                if (grid.ElementAtOrDefault(rottenOrange.Down.i) != null && grid[rottenOrange.Down.i].ElementAtOrDefault(rottenOrange.Down.j) != 0 && grid[rottenOrange.Down.i][rottenOrange.Down.j] == 1)
                {
                    grid[rottenOrange.Down.i][rottenOrange.Down.j] = 2;
                    rottensQueue.Add(new RottenOrange(rottenOrange.Down.i,rottenOrange.Down.j, rottenOrange.Wave + 1));
                    notRottenCount--;
                }
                
                result = rottenOrange.Wave;
                
            }
            
            return notRottenCount > 0 ? -1 : result;
        }
    }
    
    public class Coordinate {
        public int i {get; set;}
        public int j {get; set;}
    }

    public class RottenOrange {
        public RottenOrange(int i, int j, int wave)
        {
            Self = new Coordinate {i = i, j = j};
            Left = new Coordinate {i = i, j = j - 1};
            Up = new Coordinate {i = i - 1, j = j};
            Right = new Coordinate {i = i, j = j + 1};
            Down = new Coordinate {i = i + 1, j = j};
            Wave = wave;
        }
        public int Wave { get; set; }
        public Coordinate Self {get; set;}
        public Coordinate Left {get; set;}
        public Coordinate Up {get; set;}
        public Coordinate Right {get; set;}
        public Coordinate Down {get; set;}
    }
}
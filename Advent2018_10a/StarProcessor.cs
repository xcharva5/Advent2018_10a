using System.Collections.Generic;
using System.Linq;
using System.IO;
using static Advent2018_10a.Star;
using System.Text.RegularExpressions;

namespace Advent2018_10a
{
    class StarProcessor
    {        
        string Pattern;
        List<Star> Stars { get; set; }
        StreamReader File { get; set; }
        int DistanceX { get; set; }
        int DistanceY { get; set; }

        public StarProcessor(string path)
        {
            Pattern = @"\D{10}([-\s]\d{5}),{1}\s([-\s]\d{5})\D{12}([-\s]\d{1}),{1}\s([-\s]\d{1})\D{1}";  // regex pattern
            Stars = new List<Star>();
            File = new System.IO.StreamReader(path);
            DistanceX = int.MaxValue;
            DistanceY = int.MinValue;
        }

        public bool StarsAreClose(int dist)
        {
            // verifies if maximal distances of X and Y less than value from param
            if ((DistanceX < dist) && (DistanceY < dist)) {
                return true;
            } else
            {
                return false;
            }            
        }

        public void LoadStarsFromFile()
        {
            string line;

            // each line of input file is parsed and appropriate values are stored to List of Star objects
            while ((line = File.ReadLine()) != null)
            {
                foreach (Match m in Regex.Matches(line, Pattern))
                {
                    int posX = int.Parse(m.Groups[1].Value);
                    int posY = int.Parse(m.Groups[2].Value);
                    int velX = int.Parse(m.Groups[3].Value);
                    int velY = int.Parse(m.Groups[4].Value);

                    Stars.Add(new Star(posX, posY, velX, velY));
                }
            }

            File.Close();
        }

        public void Update()
        {
            // on each update (each second) positions of stars are recalculated based on their velocity
            foreach (Star star in Stars)
            {
                star.Position = new Values((star.Position.x + star.Velocity.x), (star.Position.y + star.Velocity.y));
            }

            // on each update (each second) maximal distances of X and Y are recalculated by current positions of stars 
            DistanceX = Stars.Max(s => s.Position.x) - Stars.Min(s => s.Position.x);  // distance between min and max X position of stars
            DistanceY = Stars.Max(s => s.Position.y) - Stars.Min(s => s.Position.y);  // distance between min and max Y position of stars
        }

        public List<string> GenerateView()
        {
            int MinX = Stars.Min(s => s.Position.x);
            int MaxX = Stars.Max(s => s.Position.x);
            int MinY = Stars.Min(s => s.Position.y);
            int MaxY = Stars.Max(s => s.Position.y);

            List<string> rows = new List<string>();

            // it is enough to draw only that part of the sky where there are currently stars
            for (int y = MinY; y < MaxY + 1; y++)
            {
                string row = "";
                for(int x = MinX; x < MaxX + 1; x++)
                {
                    // if any star has the current position, it's expressed by 'X'
                    if(Stars.Any(pos => pos.Position.x == x && pos.Position.y == y)) {
                        row += "X";
                    } else
                    {
                        row += " ";
                    }
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Advent2018_10a.Star;

namespace Advent2018_10a
{
    class StarReader
    {        
        string pattern;
        List<Star> stars;
        System.IO.StreamReader file;
        int distanceX;
        int distanceY;

        public StarReader(string path)
        {
            pattern = @"\D{10}([-\s]\d{5}),{1}\s([-\s]\d{5})\D{12}([-\s]\d{1}),{1}\s([-\s]\d{1})\D{1}";  // search just for [-\d]
            stars = new List<Star>();
            file = new System.IO.StreamReader(path);
            distanceX = Int32.MaxValue;
            distanceY = Int32.MinValue;
        }

        public bool StarsAreClose(int dist)
        {
            if ((distanceX < dist) && (distanceY < dist)) {
                return true;
            } else
            {
                return false;
            }            
        }

        public void LoadStarsFromFile()
        {
            string line;

            while ((line = file.ReadLine()) != null)
            {
                foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line, pattern))
                {
                    int posX = Int32.Parse(m.Groups[1].Value);
                    int posY = Int32.Parse(m.Groups[2].Value);
                    int velX = Int32.Parse(m.Groups[3].Value);
                    int velY = Int32.Parse(m.Groups[4].Value);

                    stars.Add(new Star(posX, posY, velX, velY));
                }
            }

            file.Close();
        }

        public void Update()
        {
            foreach(Star star in stars)
            {
                star.Position = new Values((star.Position.x + star.Velocity.x), (star.Position.y + star.Velocity.y));
            }

            distanceX = stars.Max(s => s.Position.x) - stars.Min(s => s.Position.x);  // distance between min and max X position of stars
            distanceY = stars.Max(s => s.Position.y) - stars.Min(s => s.Position.y);  // distance between min and max Y position of stars
        }

        public List<string> Display()
        {
            int x0 = stars.Min(s => s.Position.x);
            int x1 = stars.Max(s => s.Position.x);
            int y0 = stars.Min(s => s.Position.y);
            int y1 = stars.Max(s => s.Position.y);

            List<Values> starPositions = new List<Values>();
            foreach(Star star in stars)
            {
                starPositions.Add(new Values(star.Position.x, star.Position.y));
            }

            List<string> rows = new List<string>();

            for(int y = y0; y < y1+1; y++)
            {
                string row = "";
                for(int x = x0; x < x1+1; x++)
                {
                    if(stars.Any(pos => pos.x == x && pos.y == y)) {
                        row += "X";
                        //Console.WriteLine("Contains");
                    } else
                    {
                        row += ".";
                        //Console.WriteLine("Not Contains");
                    }
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}

namespace Advent2018_10a
{
    class Program
    {
        static void Main(string[] args)
        {            
            StarReader sr = new StarReader("../../../input.txt");
            StarDisplay sd = new StarDisplay(sr);

            sr.LoadStarsFromFile();
            sd.DispalyStars();           
        }
    }
    
}

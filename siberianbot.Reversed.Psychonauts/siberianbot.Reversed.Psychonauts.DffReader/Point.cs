namespace siberianbot.Reversed.Psychonauts.DffReader
{
    public class Point
    {
        public int X { get; set; }
        
        public int Y { get; set; }
    }

    public class Symbol
    {
        public Point FirstPoint { get; set; }
        
        public Point SecondPoint { get; set; }
        
        public int Unknown { get; set; }
    }
}